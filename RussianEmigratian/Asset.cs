using System.Collections.Generic;

namespace RussianEmigratian
{
    class Asset
    {

        public Dictionary<string, int> asset_store = new Dictionary<string, int>
        {
            ["Велосипед"] = 100,
            ["Ноутбук"] = 50000,
            ["Оружие"] = 70000,
            ["Машина"] = 600000,
            ["Брендовая одежда"] = 80000,
            ["Playstation 5"] = 60000,
            ["Удобная кровать"] = 50000,
            ["Квартира"] = 1400000
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
