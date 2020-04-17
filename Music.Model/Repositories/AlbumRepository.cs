using System;
using Music.Model.Data;

namespace Music.Model.Repositories
{
    public class AlbumRepository
    {

        public static Album GetById(int id)
        {
            Album album;
            using (ModelContext db = new ModelContext())
            {
                album = db.Albums.Find(id);
            }
            return album;
        }

        public static Album SaveAlbum(Album album)
        {
            using (ModelContext db = new ModelContext())
            {
                if (album.Id > 0)
                {
                    db.Albums.Update(album);
                } else
                {
                    db.Albums.Add(album);
                }
                db.SaveChanges();
            }
            return album;
                
        }
    }
}