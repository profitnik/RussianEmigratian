using System.Collections.Generic;

namespace RussianEmigratian
{
    class Asset
    {

        public Dictionary<string, int> asset_store = new Dictionary<string, int>
        {
            ["Велосипед"] = 100,
            ["Ноутбук"] = 1,
            ["Оружие"] = 1,
            ["Машина"] = 1,
            ["Брендовая одежда"] = 1,
            ["Playstation"] = 1,
            ["Удобная кровать"] = 1,
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
