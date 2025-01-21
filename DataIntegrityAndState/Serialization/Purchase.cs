using System;
using System.Collections.Generic;
using System.Text.Json;

namespace CSLab.DataIntegrityAndState.Serialization
    {
        public class Purchase
        {
            public string? ProductName { get; set; }
            public DateTime DateTime { get; set; }
            public decimal ProductPrice { get; set; }

            private static string projectRoot = AppContext.BaseDirectory;
            private static string filePath = Path.Combine(projectRoot, "..", "..", "..", "DataIntegrityAndState", "Serialization", "purchase.json");

            public static void MakeNewPurchase(string productName, decimal price)
            {
                var purchase = new Purchase()
                {
                    ProductName = productName,
                    DateTime = DateTime.UtcNow,
                    ProductPrice = price
                };

                var serializerOptions = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    WriteIndented = true,
                };

                List<Purchase> purchaseList;

                try
                {

                    if (File.Exists(filePath))
                    {
                        string existingJson = File.ReadAllText(filePath);

                        purchaseList = string.IsNullOrWhiteSpace(existingJson) ? new List<Purchase>() : JsonSerializer.Deserialize<List<Purchase>>(existingJson, serializerOptions);
                    }
                    else
                    {
                        purchaseList = new List<Purchase>();
                    }

                    purchaseList.Add(purchase);

                    string jsonString = JsonSerializer.Serialize(purchaseList, serializerOptions);

                    File.WriteAllText(filePath, jsonString);
                    Console.WriteLine("Purchase successful!");
                }
                catch (IOException ex) when (ex is FileNotFoundException or DirectoryNotFoundException)
                {
                    Console.WriteLine($"File error: {ex.Message}");
                }
                catch (JsonException ex)
                {
                    Console.WriteLine($"Json serialization error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An unexpected error occured: {ex.Message}");
                }

            }

            public static void DisplayPurchases()
            {
                try
                {                    
                    var serializerOptions = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true,
                        WriteIndented = true,
                    };

                
                    string existingJson = File.ReadAllText(filePath);
                    var purchaseList = JsonSerializer.Deserialize<List<Purchase>>(existingJson, serializerOptions);

                    Console.WriteLine("Products List");
                    foreach (var purchase in purchaseList)
                    {                        
                        Console.WriteLine($"Product: {purchase.ProductName}, price: {purchase.ProductPrice}, date: {purchase.DateTime}");
                    }
                }
                catch (IOException ex) when (ex is FileNotFoundException or DirectoryNotFoundException)
                {
                    Console.WriteLine($"File error: {ex.Message}");
                }
                catch (JsonException ex)
                {
                    Console.WriteLine($"Json serialization error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An unexpected error occured: {ex.Message}");
                }
            }

        }
    }