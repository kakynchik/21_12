namespace _21_12;

public class Backpack
{
    public string Color { get; set; }
    public string Brand { get; set; }
    public string Manufacturer { get; set; }
    public string Fabric { get; set; }
    public double Weight { get; set; }
    public double Volume { get; set; }
    
    private List<Item> contents = new List<Item>();
    public IReadOnlyList<Item> Contents => contents.AsReadOnly();
    
    public event EventHandler<Item> ItemAdded;

    public void AddItem(Item item)
    {
        double usedVolume = GetUsedVolume();
        if (usedVolume + item.Volume > Volume)
        {
            throw new InvalidOperationException("Перевищено обсяг рюкзака!");
        }

        contents.Add(item);

        ItemAdded?.Invoke(this, item);
    }

    public double GetUsedVolume()
    {
        double usedVolume = 0;
        foreach (var item in contents)
        {
            usedVolume += item.Volume;
        }
        return usedVolume;
    }
}