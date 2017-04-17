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
    public static class SQL
    {
        #region String SQL

        /// <summary>
        /// This SQL string gets all invoices from the database.
        /// </summary>
        /// <returns></returns>
        public static string GetAllInvoices()
        {
            try
            {
                return "SELECT * FROM Invoices";
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " => " + ex.Message);
            }
        }

        /// <summary>
        /// Returns a SQL statement that gets all data on an invoice for a given InvoiceID.
        /// </summary>
        /// <param name="sInvoiceID">The InvoiceID for the invoice to retrieve all data.</param>
        /// <returns>All data for the given invoice.</returns>
        public static string GetInvoice(string sInvoiceID)
        {
            try
            {
                return "SELECT * FROM Invoices WHERE InvoiceID = " + sInvoiceID;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " => " + ex.Message);
            }
        }

        /// <summary>
        /// Returns a SQL statement to get an InvoiceID given invoice date and total charge.
        /// </summary>
        /// <param name="invoice">invoice object</param>
        /// <returns>string</returns>
        public static string GetInvoiceID(Invoice invoice)
        {
            try
            {
                return "SELECT Invoice_ID FROM Invoice WHERE InvoiceDate = " + invoice.InvoiceDate + "AND TotalCharge = " + invoice.TotalCharge;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " => " + ex.Message);
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
        /// Returns a SQL statement to delete a Invoice in the Invoice table.
        /// </summary>
        /// <param name="sInvoiceID">invoice ID</param>
        /// <returns>string</returns>
        public static string DeleteInvoice(string sInvoiceID)
        {
            try
            {
                return "DELETE FROM Invoice WHERE Invoice_ID = " + sInvoiceID;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " => " + ex.Message);
            }
        }

        /// <summary>
        /// Returns a SQL statement to update an Invoice given Invoice ID.
        /// </summary>
        /// <param name="sInvoiceID">invoice ID</param>
        /// /// <param name="updateVal">value to be updated</param>
        /// <returns>string</returns>
        public static string UpdateInvoice(string sInvoiceID, string updateVal)
        {
            try
            {
                // NOT COMPLETE just a starting point
                return "UPDATE Invoice SET something = " + updateVal + "WHERE Invoice_ID = " + sInvoiceID;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " => " + ex.Message);
            }
        }

        /// <summary>
        /// Returns a SQL statement to insert an Item into the ItemDesc Table.
        /// </summary>
        /// <param name="item">item to be inserted</param>
        /// <returns>string</returns>
        public static string InsertItem(Item item)
        {
            try
            {
                return "INSERT INTO ItemDesc (ItemCode, ItemDesc, Cost) Values ('" + item.ItemCode + "','" + item.ItemDesc + "','" + item.Cost + "')";
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " => " + ex.Message);
            }
        }

        /// <summary>
        /// Returns a SQL statement to delete a Item in the ItemDesc table.
        /// </summary>
        /// <param name="sItemCode">invoice ID</param>
        /// <returns>string</returns>
        public static string DeleteItem(string sItemCode)
        {
            try
            {
                return "DELETE FROM ItemDesc WHERE ItemCode = '" + sItemCode + "'";
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " => " + ex.Message);
            }
        }

        /// <summary>
        /// Returns a SQL statement to update an Item given ItemCode.
        /// </summary>
        /// <param name="sOldItemCode">an Item's old code</param>
        /// <param name="sNewItemCode">an Item's new code</param>
        /// <param name="sNewItemDesc">an Item's new description</param>
        /// <param name="sNewItemCost">an Item's new cost</param>
        /// <returns>string</returns>
        public static string UpdateItem(string sOldItemCode, string sNewItemCode, string sNewItemDesc, string sNewItemCost)
        {
            try
            {
                return "UPDATE ItemDesc SET ItemCode = '" + sNewItemCode + "', ItemDesc = '" + sNewItemDesc + "', Cost = '" + sNewItemCost + "' WHERE ItemCode='" + sOldItemCode + "'";
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " => " + ex.Message);
            }
        }

        #endregion

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
        internal static Item LoadItem(LineItem lineItem)
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
        internal static bool InvoiceExists(int invoiceNum)
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
        internal static void UpdateInvoice(Invoice invoice)
        {
            try
            {
                var sql = $"UPDATE Invoices SET InvoiceDate = {invoice.InvoiceDate}, TotalCharge = {invoice.TotalCharge} WHERE InvoiceNum = {invoice.InvoiceNum}";
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

