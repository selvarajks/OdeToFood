using OdeToFood.Core;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
       IEnumerable <Restaurant> GetRestaurantsByName(string name);
        Restaurant GetById(int id);
    }

    public class InMemoreyRestaurantData : IRestaurantData
    {
        readonly List<Restaurant> restaurants;
        public InMemoreyRestaurantData()
        {
            restaurants = new List<Restaurant>
            {
                new Restaurant{Id =1, Name ="Scotts Pizza",Location ="MaryLand" ,Cuisine = CuisineType.Italian },
                new Restaurant{Id =2, Name ="Cinnamon club",Location ="London", Cuisine = CuisineType.Mexican},
                new Restaurant{Id =3, Name ="PonnuSamy",Location ="California",Cuisine = CuisineType.Indian}

             };

        }

        public Restaurant GetById(int id)
        {
            return restaurants.SingleOrDefault(r => r.Id == id);

        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name =null)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
                                  
        }
    }
}
