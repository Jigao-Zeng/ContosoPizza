using ContosoPizza.Models;
namespace ContosoPizza.Services;

public static class PizzaService
{
    static List<Pizza> Pizzas { get; }
    static int nextId = 3;
    static PizzaService()
    {
        Pizzas = new List<Pizza>
        {
            new Pizza { Id = 1, Name = "Classic Italian", IsGlutenFree = false},
            new Pizza { Id = 2, Name = "Veggie", IsGlutenFree = true}
        };
    }

    public static List<Pizza> GetAll() => Pizzas;

    public static Pizza? Get(int id) => Pizzas.FirstOrDefault(p => p.Id == id);

    public static void Add(Pizza pizza)
    {
        pizza.Id = nextId++;
        Pizzas.Add(pizza);
    }

    public static bool Update(Pizza pizza)
    {
        var existingPizza = Pizzas.FirstOrDefault(p => p.Id == pizza.Id);
        if (existingPizza == null)
        {
            return false; // Not found
        }

        existingPizza.Name = pizza.Name;
        existingPizza.IsGlutenFree = pizza.IsGlutenFree;

        return true; // Update successful
    }

    // Delete a pizza by ID
    public static bool Delete(int id)
    {
        var pizza = Pizzas.FirstOrDefault(p => p.Id == id);
        if (pizza == null)
        {
            return false; // Not found
        }

        Pizzas.Remove(pizza);
        return true; // Delete successful
    }
}