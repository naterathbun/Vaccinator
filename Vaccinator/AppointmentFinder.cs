using System;
using System.Collections.Generic;
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

            stores.Add(new Store()
            {
                StoreNumber = "10907",
                Address = "2100 Washington Pike, Carnegie, PA 15106"
            });

            stores.Add(new Store()
            {
                StoreNumber = "10909",
                Address = "1710 Mount Royal Blvd., Glenshaw, PA 15116"
            });

            stores.Add(new Store()
            {
                StoreNumber = "10914",
                Address = "1700 Pine Hollow Road., McKees Rocks, PA 15120"
            });

            stores.Add(new Store()
            {
                StoreNumber = "10934",
                Address = "2336 Ardmore Boulevard, Pittsburgh, PA 15221"
            });

            stores.Add(new Store()
            {
                StoreNumber = "10939",
                Address = "4411 Howley Street, Pittsburgh, PA 15224"
            });

            stores.Add(new Store()
            {
                StoreNumber = "10954",
                Address = "1125 Freeport Road, Pittsburgh, PA 15238"
            });

            stores.Add(new Store()
            {
                StoreNumber = "10975",
                Address = "201 West Mahoning Street, Punxsutawney, PA 15767"
            });

            stores.Add(new Store()
            {
                StoreNumber = "10976",
                Address = "431 Commons Drive, Dubois, PA 15801"
            });

            stores.Add(new Store()
            {
                StoreNumber = "10994",
                Address = "135 South Market Street, New Wilmington, PA 16142"
            });

            stores.Add(new Store()
            {
                StoreNumber = "10995",
                Address = "1851 East State Street, Hermitage, PA 16148"
            });

            stores.Add(new Store()
            {
                StoreNumber = "10998",
                Address = "165 Butler Road, Kittanning, PA 16201"
            });

            stores.Add(new Store()
            {
                StoreNumber = "10999",
                Address = "100 South Third Street, Conneaut Lake, PA 16316"
            });

            stores.Add(new Store()
            {
                StoreNumber = "11002",
                Address = "1020 Liberty Street, Franklin, PA 16323"
            });

            stores.Add(new Store()
            {
                StoreNumber = "1370",
                Address = "725 Lysle Boulevard, McKeesport, PA 15132"
            });

            stores.Add(new Store()
            {
                StoreNumber = "1398",
                Address = "1 East High Street, Union City, PA 16438"
            });

            stores.Add(new Store()
            {
                StoreNumber = "1406",
                Address = "521 North Fraley Street, Kane, PA 16735"
            });

            stores.Add(new Store()
            {
                StoreNumber = "1496",
                Address = "508 East Second Street, Oil City, PA 16301"
            });

            stores.Add(new Store()
            {
                StoreNumber = "1548",
                Address = "610 Broad Street, New Bethlehem, PA 16242"
            });

            stores.Add(new Store()
            {
                StoreNumber = "1668",
                Address = "700 Sharon New Castle Rd., Farrell, PA 16121"
            });

            stores.Add(new Store()
            {
                StoreNumber = "1699",
                Address = "9141 Ridge Road, Girard, PA 16417"
            });

            stores.Add(new Store()
            {
                StoreNumber = "213",
                Address = "2715 Parade Street, Erie, PA 16504"
            });

            stores.Add(new Store()
            {
                StoreNumber = "2380",
                Address = "975 Market Street, Meadville, PA 16335"
            });

            stores.Add(new Store()
            {
                StoreNumber = "2382",
                Address = "163 West 26th Street, Erie, PA 16508"
            });

            stores.Add(new Store()
            {
                StoreNumber = "2474",
                Address = "59 North Main Street, Port Allegany, PA 16743"
            });

            stores.Add(new Store()
            {
                StoreNumber = "2476",
                Address = "101 Main Street, Ridgway, PA 15853"
            });

            stores.Add(new Store()
            {
                StoreNumber = "264",
                Address = "375 Philadelphia Street, Indiana, PA 15701"
            });

            stores.Add(new Store()
            {
                StoreNumber = "274",
                Address = "1700 Murray Avenue, Pittsburgh, PA 15217"
            });

            stores.Add(new Store()
            {
                StoreNumber = "2769",
                Address = "100 Franklin Street, Mercer, PA 16137"
            });

            stores.Add(new Store()
            {
                StoreNumber = "3449",
                Address = "335 Main Street, Greenville, PA 16125"
            });

            stores.Add(new Store()
            {
                StoreNumber = "3527",
                Address = "155 Chartiers Avenue, McKees Rocks, PA 15136"
            });

            stores.Add(new Store()
            {
                StoreNumber = "3972",
                Address = "811 East State Street, Sharon, PA 16146"
            });

            stores.Add(new Store()
            {
                StoreNumber = "4616",
                Address = "208 East Central Avenue, Titusville, PA 16354"
            });

            stores.Add(new Store()
            {
                StoreNumber = "4682",
                Address = "100 William Marks Drive, Munhall, PA 15120"
            });

            stores.Add(new Store()
            {
                StoreNumber = "596",
                Address = "827 N. Center Street, Corry, PA 16407"
            });

            stores.Add(new Store()
            {
                StoreNumber = "740",
                Address = "8878 Clearfield Curwensville, Clearfield, PA 16830"
            });

            stores.Add(new Store()
            {
                StoreNumber = "7853",
                Address = "901 S Saint Marys Street, Saint Marys, PA 15857"
            });

            return stores;
        }

        private string CreateURL(string storeNumber)
        {
            return "https://www.riteaid.com/services/ext/v2/vaccine/checkSlots?storeNumber=" + storeNumber;
        }
    }
}
