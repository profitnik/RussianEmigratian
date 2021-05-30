using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RussianEmigratian
{
    class Asset
    {

        public Dictionary<string, int> asset_store = new Dictionary<string, int>
        {
            ["Велосипед"] = 25,
            ["Ноутбук"] = 40,
            ["Оружие"] = 50,
            ["Машина"] = 100,
            ["Брендовая одежда"] = 50,
            ["Playstation"] = 30,
            ["Удобная кровать"] = 20,
            ["Квартира"] = 200
        };

        private int discount = 2; // Делитель для цены, когда игрок продает имущество обратно
        public Dictionary<string, int> asset_person = new Dictionary<string, int>();

        public void Buy(string asset)
        {
            int price_key = 0;
            asset_store.TryGetValue(asset, out price_key);
            asset_person.Add(asset, price_key/discount);
            asset_store.Remove(asset);
        }
        public void Sell(string asset)
        {
            int price_key = 0;
            asset_person.TryGetValue(asset, out price_key);
            asset_store.Add(asset, price_key * discount);
            asset_person.Remove(asset);
        }
    }
}
