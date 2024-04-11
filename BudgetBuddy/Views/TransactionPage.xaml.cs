using BudgetBuddy.Data;
using BudgetBuddy.Models;
using BudgetBuddy.Views;


namespace BudgetBuddy.Views
{
    public partial class TransactionPage : ContentPage
    {
        PayItemItemDatabase database;
        ListView transactionsListView;

        public TransactionPage()
        {

            Title = "Transaction List";
            database = new PayItemItemDatabase();
            transactionsListView = new ListView();
            transactionsListView.ItemTemplate = new DataTemplate(typeof(TransactionCell));
            transactionsListView.RowHeight = 70;
            transactionsListView.ItemSelected += OnTransactionSelected;

            var searchBar = new SearchBar();
            searchBar.HorizontalOptions = LayoutOptions.FillAndExpand;
            searchBar.Margin = new Thickness(0, 10, 0, 30);
            searchBar.Placeholder = "Search transactions...";   
            searchBar.SearchButtonPressed += SearchBar_SearchButtonPressed;

            var stackLayout = new StackLayout();
            stackLayout.Children.Add(searchBar);
            stackLayout.Children.Add(transactionsListView);

            Content = stackLayout;

            LoadTransactions();
        }
        private async void SearchBar_SearchButtonPressed(object sender, EventArgs e)
        {
            var searchBar = (SearchBar)sender;
            string searchText = searchBar.Text.ToLower();

            if (string.IsNullOrWhiteSpace(searchText))
            {
                LoadTransactions();
                return;
            }

            List<PayItem> transactions = await database.GetAllTransactionsAsync();
            IEnumerable<PayItem> filteredTransactions = transactions.Where(t => t.Name.ToLower().Contains(searchText) || t.Category.ToLower().Contains(searchText) || t.AmountText.ToLower().Contains(searchText));
            transactionsListView.ItemsSource = filteredTransactions;
        }
        private async void LoadTransactions()
        {
            List<PayItem> transactions = await database.GetAllTransactionsAsync();
            transactionsListView.ItemsSource = transactions;
        }

        private async void OnTransactionSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                PayItem selectedTransaction = (PayItem)e.SelectedItem;
                await Navigation.PushAsync(new PayItemPage
                {
                    BindingContext = selectedTransaction
                });
                transactionsListView.SelectedItem = null; // deselect the item
            }
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SearchPage());
        }
    }

    // Custom cell for displaying transaction data
    public class TransactionCell : ViewCell
    {
        public TransactionCell()
        {
            var nameLabel = new Label();
            nameLabel.Margin = new Thickness(5,1,0,1);
            nameLabel.SetBinding(Label.TextProperty, "Name");

            var amountLabel = new Label();
            amountLabel.Margin = new Thickness(5, 1, 0, 1);
            amountLabel.SetBinding(Label.TextProperty, "AmountText");

            var categoryLabel = new Label();
            categoryLabel.Margin = new Thickness(5, 1, 0, 10);
            categoryLabel.SetBinding(Label.TextProperty, "Category");

            

            View = new StackLayout
            {
                Padding = new Thickness(0),
                VerticalOptions = LayoutOptions.StartAndExpand, // Set the vertical options to start and expand
                Children = { nameLabel, amountLabel, categoryLabel }
            };
        }
    }
}