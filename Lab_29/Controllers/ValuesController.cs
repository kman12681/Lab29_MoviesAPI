using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Lab_29.Models;
using Microsoft.Ajax.Utilities;

namespace Lab_29.Controllers
{
    public class ValuesController : ApiController
    {
        MoviesEntities db = new MoviesEntities();
        Random random = new Random();

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

            int id = random.Next(1, (db.Movies.Count() + 1));

            Movy movie = (from m in db.Movies
                          where m.ID == id
                          select m).Single();

            return movie;
        }

        public Movy GetRandomMovieFromGenre(string id)
        {

            List<Movy> movies = (from m in db.Movies
                                 where m.Genre == id
                                 select m).ToList();

            int rand = random.Next(0, movies.Count);

            Movy movie = movies[rand];

            return movie;

        }

        public List<Movy> GetRandomMovies(int id)
        {
            List<Movy> list = db.Movies.ToList();
            List<Movy> movies = new List<Movy>();
            
            for (int i = 0; i < id; i++)
            {
                int rand = random.Next(0, list.Count);
                movies.Add(list[rand]);
            }

            return movies;

        }

        public List<Movy> GetAllGenres()
        {
            List<Movy> movies = db.Movies.ToList();
            List<Movy> genres = (from m in movies
                                 select new Movy()
                                 {
                                     Genre = m.Genre,                                   
                                 }).GroupBy(x => x.Genre).Select(z => z.OrderBy(i => i.Genre).First()).ToList();
            return genres;

        }

        public Movy GetMovieDetails(string id)
        {
            List<Movy> movies = db.Movies.ToList();
            Movy movie = (from m in movies
                          where m.Title == id
                          select m).Single();

            return movie;
        }

        public List<Movy> GetMoviesByKeyword(string id)
        {
            List<Movy> movies = (from m in db.Movies
                                 where m.Title.Contains(id)
                                 select m).ToList();

            return movies;

        }



    }
}
