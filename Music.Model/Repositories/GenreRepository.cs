using Music.Model;
using Music.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Music.Model.Repositories
{
    public class GenreRepository
    {
        //public static Genre GetById(int id)
        //{
        //    Genre genre;
        //    using (ModelContext db = new ModelContext())
        //    {
        //        genre = db.Genres.Find(id);
        //    }
        //    return genre;
        //}

        //public static Genre SaveGenre(Genre genre)
        //{
        //    using (ModelContext db = new ModelContext())
        //    {
        //        if (genre.Id > 0)
        //        {
        //            db.Genres.Update(genre);
        //        }
        //        else
        //        {
        //            db.Genres.Add(genre);
        //        }
        //        db.SaveChanges();
        //    }
        //    return genre;

        //}

        //public static List<Genre> GetList()
        //{
        //    using (ModelContext db = new ModelContext())
        //    {
        //        return db.Genres.ToList();
        //    }
        //}

        //public static Genre GetGenreByName(string name)
        //{
        //    using (ModelContext db = new ModelContext())
        //    {
        //        Genre genre = db.Genres.FirstOrDefault(g => g.Name == name);
        //        if (genre != null)
        //        {
        //            return genre;
        //        }
        //        genre = new Genre { Name = name };
        //        db.Genres.Add(genre);
        //        db.SaveChanges();
        //        return genre;
        //    }
        //}
    }
}
