public class GameManager
{
    private static GameManager _instance;
    public static GameManager Instance => _instance ??= new GameManager();

    public int myMoney = 3000;

    public Inventory myInventory = new Inventory();
    public Inventory shopInventory = new Inventory();

    private GameManager() { }

}
