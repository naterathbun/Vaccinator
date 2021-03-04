using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json;

namespace Vaccinator
{
    public class AppointmentFinder
    {        
        public void FindAppointmentStatus()
        {
            var stores = GetStores();
            var webRequestExecutor = new WebRequestExecutor();

            foreach (var store in stores)
            {
                var url = CreateURL(store.StoreNumber);
                var response = webRequestExecutor.Get(url);
                var storeStatus = new StoreStatus();

                try
                {
                    storeStatus = JsonConvert.DeserializeObject<StoreStatus>(response);
                    var hasAppointment = false;

                    if (storeStatus.Data == null)
                        break;

                    foreach (KeyValuePair<string, bool> entry in storeStatus.Data.slots)
                    {
                        if (entry.Value)
                            hasAppointment = true;
                    }

                    if (hasAppointment)
                        Console.Write("\nStore #" + store.StoreNumber + ": " + store.Address);
                }
                catch (Exception)
                {
                }
            }
        }

        private List<Store> GetStores()
        {
            var stores = new List<Store>();
            var path = @"E:\Vaccinator\StoreList.csv";

            using (var reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    stores.Add(new Store()
                    {
                        StoreNumber = values[0],
                        Address = values[1]
                    });
                }
            }

            return stores;
        }

        private string CreateURL(string storeNumber)
        {
            return "https://www.riteaid.com/services/ext/v2/vaccine/checkSlots?storeNumber=" + storeNumber;
        }
    }
}