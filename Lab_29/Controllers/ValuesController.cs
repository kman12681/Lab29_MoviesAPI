using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Lab_29.Models;

namespace Lab_29.Controllers
{
    public class ValuesController : ApiController
    {
        MoviesEntities db = new MoviesEntities();

        public List<Movy> GetMovies()
        {
            List<Movy> movies = db.Movies.ToList();
            return movies;

        }

        public List<Movy> GetMoviesByGenre(string id)
        {

            List<Movy> movies = (from m in db.Movies
                                 where m.Genre == id
                                 select m).ToList();

            return movies;

        }

        public Movy GetRandomMovie()
        {

            Random random = new Random();
            int id = random.Next(1, (db.Movies.Count() + 1));

            Movy movie = (from m in db.Movies
                          where m.ID == id
                          select m).Single();

                          return movie;
        }

        public Movy GetRandomMovieFromGenre(string id)
        {
            Random random = new Random();
            List<Movy> movies = (from m in db.Movies
                                 where m.Genre == id
                                 select m).ToList();            
            
            int rand = random.Next(0, movies.Count);

            Movy movie = movies[rand];

            return movie;
           
        }

     
        


    }
}
