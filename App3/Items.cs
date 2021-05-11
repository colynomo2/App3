using Android.Runtime;
using Java.Lang;
using System;
using System.Collections.Generic;

namespace App3
{
    public class Item
    {
       public Item() { }
        public Item(int id, string text)
        {
            ItemID = id;
            Text = text;
            Counter = 0;
        }

        public int Counter { get; set; }
        public int ItemID { get; }

       
        public string Text { get; }
    }

   
    public class Items
    {
      

         JavaList<Item> mBuiltInItems = new JavaList<Item>{
            new Item ( Resource.Mipmap.firstImage,
                        "Buckingham Palace" ),
            new Item ( Resource.Mipmap.secondImage,
            "The Eiffel Tower" ),
            new Item ( Resource.Mipmap.thirdImage,
                       "The Louvre" ),
            new Item ( Resource.Mipmap.firstImage,
                        "Before mobile phones" ),
            new Item ( Resource.Mipmap.secondImage,
                        "Big Ben skyline" ),
            new Item ( Resource.Mipmap.thirdImage,
                        "Big Ben from below" ),
           new Item ( Resource.Mipmap.firstImage,
                       "The London Eye" ),
            new Item ( Resource.Mipmap.secondImage,
                        "Eurostar Train" ),
            //new Item ( Resource.Drawable.arc_de_triomphe,
            //            "Arc de Triomphe" ),
            //new Item ( Resource.Drawable.louvre_2,
            //            "Inside the Louvre" ),
            //new Item ( Resource.Drawable.versailles_fountains,
            //            "Versailles fountains" ),
            //new Item ( Resource.Drawable.modest_accomodations,
            //            "Modest accomodations" ),
            //new Item ( Resource.Drawable.notre_dame,
            //            "Notre Dame" ),
            //new Item ( Resource.Drawable.inside_notre_dame,
            //            "Inside Notre Dame" ),
            //new Item ( Resource.Drawable.seine_river,
            //            "The Seine" ),
            //new Item ( Resource.Drawable.rue_cler,
            //            "Rue Cler" ),
            //new Item ( Resource.Drawable.champ_elysees,
            //            "The Avenue des Champs-Elysees" ),
            //new Item ( Resource.Drawable.seine_barge,
            //            "Seine barge" ),
            //new Item ( Resource.Drawable.versailles_gates,
            //            "Gates of Versailles" ),
            //new Item ( Resource.Drawable.edinburgh_castle_2,
            //            "Edinburgh Castle" ),
            //new Item ( Resource.Drawable.edinburgh_castle_1,
            //            "Edinburgh Castle up close" ),
            //new Item ( Resource.Drawable.old_meets_new,
            //            "Old meets new" ),
            //new Item ( Resource.Drawable.edinburgh_from_on_high,
            //            "Edinburgh from on high" ),
            //new Item ( Resource.Drawable.edinburgh_station,
            //            "Edinburgh station" ),
            //new Item ( Resource.Drawable.scott_monument,
            //            "Scott Monument" ),
            //new Item ( Resource.Drawable.view_from_holyrood_park,
            //            "View from Holyrood Park" ),
            //new Item ( Resource.Drawable.tower_of_london,
            //            "Outside the Tower of London" ),
            //new Item ( Resource.Drawable.tower_visitors,
            //            "Tower of London visitors" ),
            //new Item ( Resource.Drawable.one_o_clock_gun,
            //            "One O'Clock Gun" ),
            //new Item ( Resource.Drawable.victoria_albert,
            //            "Victoria and Albert Museum" ),
            //new Item ( Resource.Drawable.royal_mile,
            //            "The Royal Mile" ),
            //new Item ( Resource.Drawable.museum_and_castle,
            //            "Edinburgh Museum and Castle" ),
            //new Item ( Resource.Drawable.portcullis_gate,
            //            "Portcullis Gate" ),
            //new Item ( Resource.Drawable.to_notre_dame,
            //            "Left or right?" ),
            //new Item ( Resource.Drawable.pompidou_centre,
            //            "Pompidou Centre" ),
            //new Item ( Resource.Drawable.heres_lookin_at_ya,
            //            "Here's Lookin' at Ya!" ),
            };

     

        private JavaList<Item> mItems;


        internal JavaList<Item> getItems()
        {
            return mItems;
        }

        public Items()
        {
            mItems = mBuiltInItems; 
        }
        public void setItems(JavaList<Item> list)
        {
            mItems = list;
        }
        public int NumItems
        {
            get { return mItems.Count; }
        }
        
        public Item this[int i]
        {
            get { return mItems[i]; }
        }

        
    }
}