using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.IO;

namespace Guild_Wars_2_AutoTrader.Entities
{
    public class Weapon
    {
        public int index = 0;
        public object id { get; set; }
        public int item_id { get; set; }
        public string name { get; set; }
        public int level { get; set; }
        public string rarity { get; set; }
        public string icon { get; set; }
        public string weapon_type { get; set; }

        public int buys_unit_price { get; set; }
        public int gold { get; set; }
        public int silver { get; set; }
        public int sells_unit_price { get; set; }
        public int sellPrice { get; set; }
        public int buyQuantity { get; set; }

        public string offer_availability { get; set; }
        public string sale_availability { get; set; }

        public int inventory_quantity { get; set; }

        public Weapon()
        {

        }

        public Weapon(int item_id, string getType)
        {
            this.item_id = item_id;

            getWeaponInfo();

            if (getType == Enum.GetName(typeof(Entities.Constants.getType), 0))
            {
                getBuyAndSellPrice();
                getSellPrice();
                getGold();
                getSilver();
                getBuyQuantity();
            }

            if (getType == Enum.GetName(typeof(Entities.Constants.getType), 1))
            {
                getInventoryQuantity();
            }
            
        }

        public string getWeaponJSON(string URL)
        {
            return getJSONString(URL);
        }

        public string getJSONString(string URL)
        {
            using (var webClient = new System.Net.WebClient())
            {
                var jsonString = webClient.DownloadString(URL);

                return jsonString;
            }
        }

        public void getWeaponInfo()
        {
            string URL = Constants.URL_items + this.item_id.ToString();

            string jsonString = getWeaponJSON(URL);

            dynamic weaponJSON = JsonConvert.DeserializeObject(jsonString);

            if (weaponJSON.name != null)
            {
                this.name = weaponJSON.name;
            }

            if (weaponJSON.level != null)
            {
                this.level = weaponJSON.level;
            }

            if (weaponJSON.rarity != null)
            {
                this.rarity = weaponJSON.rarity;
            }

            if (weaponJSON.icon != null)
            {
                string temp;
                temp = weaponJSON.icon;
                this.icon = temp.Trim(new Char[] {'"'});
            }

            if (weaponJSON.details.type != null)
            {
                this.weapon_type = weaponJSON.details.type;
            }
        }

        public void getBuyAndSellPrice()
        {
            string URL = Constants.URL_itemBuySellPrice + this.item_id.ToString();

            string jsonString = getWeaponJSON(URL);

            dynamic weaponJSON = JsonConvert.DeserializeObject(jsonString);

            if (weaponJSON.buys.unit_price != null)
            {
                this.buys_unit_price = weaponJSON.buys.unit_price;
            }

            if (weaponJSON.sells.unit_price != null)
            {
                this.sells_unit_price = weaponJSON.sells.unit_price;
            }

        }

        public void getInventoryQuantity()
        {

        }

        public int getProfit()
        {
            int sellPrice85 = (int)(this.sells_unit_price * .85);
            return sellPrice85 - this.buys_unit_price;
        }

        public decimal ROI()
        {
            int profit = getProfit();
            int buyPrice = this.buys_unit_price;
            return (decimal)profit / (decimal)buyPrice;
        }

        public bool isAboveMinROI()
        {
            if (this.ROI() > Constants.minROI)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool isBelowMaxBuyPrice()
        {
            if (this.buys_unit_price < Constants.maxBuyPrice)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool isStringShort()
        {
            if (this.name.Length <= Constants.maxStringLegth)
            {
                return true;
            }
            else
            {
                return true;

            }
        }

        public bool canBuyItem()
        {
            if (this.isBelowMaxBuyPrice() && this.isAboveMinROI() && this.isStringShort())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void getBuyQuantity()
        {
            if(this.buys_unit_price <= Constants.oneGold[0])
            {
                this.buyQuantity = Constants.oneGold[1];
            }
            else if(this.buys_unit_price <= Constants.twoGold[0])
            {
                this.buyQuantity = Constants.twoGold[1];
            }
            else if (this.buys_unit_price <= Constants.fiveGold[0])
            {
                this.buyQuantity = Constants.fiveGold[1];
            }
            else if(this.buys_unit_price <= Constants.tenGold[0])
            {
                this.buyQuantity = Constants.tenGold[1];
            }
            else
            {
                this.buyQuantity = Constants.tenGold[2];
            }
        }

        public void getSellPrice()
        {
            decimal weaponROI = 0.0m;
            if(this.ROI() > Constants.minROI)
            {
                this.sellPrice = 0;
                return;
            }
            else if (this.ROI() > 0.0m)
            {
                weaponROI = Constants.minROI - this.ROI();
            }
            else
            {
                weaponROI = Constants.minROI + Math.Abs(this.ROI());
            }
            if (!this.isAboveMinROI())
            {
                decimal sPrice = this.sells_unit_price * (1 + weaponROI);
                this.sellPrice = (int) Math.Round(sPrice);
            }
            else
            {
                this.sellPrice = 0;
            }
        }

        public bool isSellPriceZero()
        {
            return this.sellPrice == 0 ? true : false;
        }

        public void getGold()
        {
            string gold = "";

            if (!isSellPriceZero())
            {
                gold = this.sellPrice.ToString();

                gold = gold.Substring(0, gold.Length - 4);

                this.gold = Int32.Parse(gold);
            }
            else
            {
                this.gold = 0;
            }
            
        }

        public void getSilver()
        {
            if (!isSellPriceZero())
            {
                string silver = "";

                silver = this.sellPrice.ToString();

                silver = silver.Substring(silver.Length - 4, 2);

                this.silver = Int32.Parse(silver);
            }
            else
            {
                this.silver = 0;
            }
        }

    }

    
}
