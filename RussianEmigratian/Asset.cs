using System.Collections.Generic;

namespace RussianEmigratian
{
    class Asset
    {

        public Dictionary<string, int> asset_store = new Dictionary<string, int>
        {
            ["Велосипед"] = 5000,
            ["Ноутбук"] = 35000,
            ["Оружие"] = 60000,
            ["Машина"] = 230000,
            ["Брендовая одежда"] = 120000,
            ["Playstation"] = 50000,
            ["Удобная кровать"] = 40000,
        };

        private int discount = 2; // Делитель для цены, когда игрок продает имущество обратно
        public Dictionary<string, int> asset_person = new Dictionary<string, int>(); // Имущество игрока

        public void Buy(string asset)
        {
            int price_key = 0;
            asset_store.TryGetValue(asset, out price_key);
            asset_person.Add(asset, price_key / discount);
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
