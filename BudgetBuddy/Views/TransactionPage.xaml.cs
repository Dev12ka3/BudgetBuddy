using BudgetBuddy.Data;
using BudgetBuddy.Models;
using BudgetBuddy.Views;
using System;


namespace BudgetBuddy.Views;

public partial class TransactionPage : ContentPage
{
    PayItemItemDatabase database;
    ListView transactionsListView;

    public TransactionPage()

    {
        InitializeComponent();

        Title = "Transaction List";
        database = new PayItemItemDatabase();

        transactionsListView = new ListView();
        transactionsListView.ItemTemplate = new DataTemplate(typeof(TransactionCell));

        Content = transactionsListView;

        LoadTransactions();
    }

    private async void LoadTransactions()
    {
        List<PayItem> transactions = await database.GetAllTransactionsAsync();
        transactionsListView.ItemsSource = transactions;
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
        nameLabel.SetBinding(Label.TextProperty, "Name");

        var amountLabel = new Label();
        amountLabel.SetBinding(Label.TextProperty, "AmountText");

        var categoryLabel = new Label();
        categoryLabel.SetBinding(Label.TextProperty, "Category");


        View = new StackLayout
        {
            Padding = new Thickness(10),
            Children = { nameLabel, amountLabel, categoryLabel }
        };
    }



}