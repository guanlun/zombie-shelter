public class Inventory {
    public const int numItems = 10;
    public Item[] items = new Item[numItems];

    public void AddItem(Item item) {
        for (int i = 0; i < Inventory.numItems; i++) {
            if (this.items[i] == null) {
                this.items[i] = item;
            }
        }
    }
}
