using InvoiceSystem.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Linq;
using InvoiceSystem.Models;
using System.Globalization;

namespace InvoiceSystem
{
    /// <summary>
    /// Contains the SQL statements for managing the invoice data.
    /// 
    /// This part of the assignment is to create a class that contains the main pieces of SQL used throughout the project.  
    /// This class will be nothing but methods that contain different statements of SQL.  
    /// Make sure to create SQL statements that will help in meeting all requirements that use the database.  
    /// So SQL statements needed will be to select different types of data on each window, to update/insert/delete data on each form.  
    /// Use Microsoft Access to run the queries ahead of time to make sure the queries give you the expected data and work correctly.  
    /// Your SQL statements should be tested and working.  Below is an example of a class/method that should be used as a guide for your code.
    /// </summary>
    public static class DataStore
    {
        /// <summary>
        /// Adds an item to invoice.
        /// </summary>
        /// <param name="invoice"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public static int AddItemToInvoice(Invoice invoice, Item item)
        {
            try
            {
                var datastore = new Database();

                var sql = $"SELECT MAX(LineItemNum) FROM LineItems WHERE InvoiceNum = {invoice.InvoiceNum.ToString(NumberFormatInfo.InvariantInfo)}";
                var result = datastore.ExecuteScalarSQL(sql);

                if (!int.TryParse(result, out var lineItemNum))
                {
                    lineItemNum = 1;
                }
                else
                {
                    ++lineItemNum;
                }

                sql = $"INSERT INTO LineItems(InvoiceNum, LineItemNum, ItemCode) VALUES({invoice.InvoiceNum.ToString(NumberFormatInfo.InvariantInfo)} , {lineItemNum.ToString(NumberFormatInfo.InvariantInfo)} , '{item.ItemCode}')";
                datastore.ExecuteNonQuery(sql);
                return lineItemNum;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Returns a SQL statement to insert an Invoice into the Invoice Table.
        /// </summary>
        /// <param name="invoice">invoice object to be inserted</param>
        /// <returns>string</returns>
        public static int InsertInvoice(Invoice invoice)
        {
            try
            {
                var datastore = new Database(); 

                var sql = "SELECT MAX(InvoiceNum) FROM Invoices";
                var result = datastore.ExecuteScalarSQL(sql);

                if (!int.TryParse(result, out var invoiceNum))
                {
                    invoiceNum = 1;
                }
                else
                {
                    ++invoiceNum;
                }

                sql = $"INSERT INTO Invoices (InvoiceNum, InvoiceDate, TotalCharge) Values ({invoiceNum.ToString(NumberFormatInfo.InvariantInfo)}, '{invoice.InvoiceDate.ToString(NumberFormatInfo.InvariantInfo)}', {invoice.TotalCharge.ToString(NumberFormatInfo.InvariantInfo)})";
                datastore.ExecuteNonQuery(sql);

                return invoiceNum;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " => " + ex.Message);
            }
        }


        /// <summary>
        /// Loads the invoices from the database and returns the data as a IList of Invoices
        /// </summary>
        /// <returns></returns>
        public static IList<Invoice> LoadAllInvoices()
        {
            try
            {
                var sql = @"SELECT InvoiceNum, InvoiceDate, TotalCharge FROM Invoices";

                var count = 0;
                var result = new Database().ExecuteSQLStatement(sql, ref count);
                var table = result.Tables[0];
                var columns = table.Columns;
                var invoiceNumColumn = columns["InvoiceNum"];
                var invoiceDateColumn = columns["InvoiceDate"];
                var totalChargeColumn = columns["TotalCharge"];

                var invoicesQuery =
                   from DataRow row in result.Tables[0].Rows
                   select new Invoice
                   {
                       InvoiceNum = (int)row[invoiceNumColumn],
                       InvoiceDate = (DateTime)row[invoiceDateColumn],
                       TotalCharge = (decimal)row[totalChargeColumn]
                   };

                return invoicesQuery.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }


        /// <summary>
        /// Get all items from database.
        /// </summary>
        /// <returns></returns>
        public static IList<Item> LoadAllItems()
        {
            try
            {
                var sql = @"SELECT * FROM ItemDesc";

                var count = 0;
                var result = new Database().ExecuteSQLStatement(sql, ref count);
                var table = result.Tables[0];
                var columns = table.Columns;
                var itemCodeColumn = columns["ItemCode"];
                var itemDescColumn = columns["ItemDesc"];
                var costColumn = columns["Cost"];

                var itemsQuery =
                   from DataRow row in result.Tables[0].Rows
                   select new Item
                   {
                       ItemCode = (string)row[itemCodeColumn],
                       ItemDesc = (string)row[itemDescColumn],
                       Cost = (decimal)row[costColumn]
                   };

                return itemsQuery.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }


        /// <summary>
        /// Get the line items for the invoice.
        /// </summary>
        /// <returns></returns>
        public static IList<LineItem> LoadLineItems(Invoice invoice)
        {
            try
            {
                var sql = $"SELECT * FROM LineItems WHERE {invoice.InvoiceNum} = InvoiceNum";

                var count = 0;
                var result = new Database().ExecuteSQLStatement(sql, ref count);
                var table = result.Tables[0];
                var columns = table.Columns;
                var invoiceNumColumn = columns["InvoiceNum"];
                var lineItemNumColumn = columns["LineItemNum"];
                var itemCodeColumn = columns["ItemCode"];

                var lineItemsQuery =
                   from DataRow row in result.Tables[0].Rows
                   select new LineItem
                   {
                       InvoiceNumber = (int)row[invoiceNumColumn],
                       LineItemNumber = (int)row[lineItemNumColumn],
                       ItemCode = (string)row[itemCodeColumn]
                   };

                return lineItemsQuery.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }


        /// <summary>
        /// Loads the Item from of with the itemcode of the given lineItem
        /// </summary>
        /// <param name="lineItem"></param>
        /// <returns></returns>
        public static Item LoadItem(LineItem lineItem)
        {
            try
            {
                var sql =
                $"SELECT * FROM ItemDesc WHERE '{lineItem.ItemCode}' = ItemCode";

                var count = 0;
                var result = new Database().ExecuteSQLStatement(sql, ref count);
                var table = result.Tables[0];
                var columns = table.Columns;
                var itemCodeColumn = columns["ItemCode"];
                var itemDescColumn = columns["ItemDesc"];
                var costColumn = columns["Cost"];

                var itemsQuery =
                   from DataRow row in result.Tables[0].Rows
                   select new Item
                   {
                       ItemCode = (string)row[itemCodeColumn],
                       ItemDesc = (string)row[itemDescColumn],
                       Cost = (decimal)row[costColumn]
                   };

                return itemsQuery.ToList()[0];
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }


        /// <summary>
        /// Returns true if the Invoice exists for the given invoice number
        /// </summary>
        /// <param name="invoiceNum"></param>
        /// <returns></returns>
        public static bool InvoiceExists(int invoiceNum)
        {
            try
            {
                var datastore = new Database();
                var sql = $"SELECT 1 FROM Invoices WHERE InvoiceNum = {invoiceNum}";
                var exists = datastore.ExecuteScalarSQL(sql);
                return !string.IsNullOrWhiteSpace(exists);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }


        /// <summary>
        /// Updates the given invoice.
        /// </summary>
        /// <param name="invoice"></param>
        public static void UpdateInvoice(Invoice invoice)
        {
            try
            {
                var sql = $"UPDATE Invoices SET InvoiceDate = '{invoice.InvoiceDate}', TotalCharge = {invoice.TotalCharge.ToString(NumberFormatInfo.InvariantInfo)} WHERE InvoiceNum = {invoice.InvoiceNum.ToString(NumberFormatInfo.InvariantInfo)}";
                var datastore = new Database();
                datastore.ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }


        /// <summary>
        /// Returns true if the Item exists on an invoice.
        /// </summary>
        /// <param name="itemCode"></param>
        /// <returns></returns>
        public static IList<LineItem> ItemExistsOnInvoice(string itemCode)
        {
            try
            {
                int ret = 0;
                var datastore = new Database();
                var sql = $"SELECT * FROM LineItems WHERE ItemCode = '{itemCode}'";
                var result = datastore.ExecuteSQLStatement(sql, ref ret);
                var table = result.Tables[0];
                var columns = table.Columns;
                var invoiceNumCol = columns["InvoiceNum"];
                var lineItemNumCol = columns["LineItemNum"];
                var itemCodeCol = columns["ItemCode"];

                var invoicesQuery =
                   from DataRow row in result.Tables[0].Rows
                   select new LineItem
                   {
                       InvoiceNumber = (int)row[invoiceNumCol],
                       LineItemNumber = (int)row[lineItemNumCol],
                       ItemCode = (string)row[itemCodeCol]
                   };

                var returnList = invoicesQuery.ToList();

                if (returnList.Count == 0)
                {
                    return null;
                }

                return invoicesQuery.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }


        /// <summary>
        /// Returns true if the Item exists for the given item code.
        /// </summary>
        /// <param name="itemCode"></param>
        /// <returns></returns>
        public static bool ItemExists(string itemCode)
        {
            try
            {
                var datastore = new Database();
                var sql = $"SELECT 1 FROM ItemDesc WHERE ItemCode = '{itemCode}'";
                var exists = datastore.ExecuteScalarSQL(sql);
                return !string.IsNullOrWhiteSpace(exists);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }


        /// <summary>
        /// Save item to database.
        /// </summary>
        /// <param name="item"></param>
        public static void InsertItem(Item item)
        {
            try
            {
                var datastore = new Database();

                var sql = $"INSERT INTO ItemDesc (ItemCode, ItemDesc, Cost) VALUES('{item.ItemCode}', '{item.ItemDesc}', {item.Cost.ToString(NumberFormatInfo.InvariantInfo)})";
                datastore.ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }


        /// <summary>
        /// Update an item in the database.
        /// </summary>
        /// <param name="item">item to be updated</param>
        public static void UpdateItem(Item item)
        {
            try
            {
                var sql = $"UPDATE ItemDesc SET ItemCode = '{item.ItemCode}', ItemDesc = '{item.ItemDesc}', Cost = {item.Cost.ToString(NumberFormatInfo.InvariantInfo)} " +
                          $"WHERE ItemCode = '{item.ItemCode}'";
                var datastore = new Database();
                datastore.ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Deletes an item from database.
        /// </summary>
        /// <param name="item"></param>
        public static void DeleteItem(Item item)
        {
            try
            {
                var sql = $"DELETE FROM ItemDesc WHERE ItemCode = '{item.ItemCode}'";
                var datastore = new Database();
                datastore.ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
    }
}

