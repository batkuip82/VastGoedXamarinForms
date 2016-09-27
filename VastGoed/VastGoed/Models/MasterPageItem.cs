using System;
using System.Collections.Generic;
using VastGoed.Views;

namespace VastGoed.Models
{
    public class MasterPageItem
    {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public string IconSource  { get; private set; }
        public Type TargetType { get; private set; }

        public static List<MasterPageItem> GetMenuItems()
        {
            return new List<MasterPageItem>
            {
                new MasterPageItem
                {
                    Id = 0,
                    Title = "Home",
                    IconSource  = "",
                    TargetType = typeof(NewsListPageView)
                },
                new MasterPageItem
                {
                    Id = 1,
                    Title = "Nieuws",
                    IconSource  = "",
                    TargetType = typeof(NewsListPageView)
                },
                new MasterPageItem
                {
                    Id = 2,
                    Title = "Transactie",
                    IconSource  = "",
                    TargetType = typeof(NewsListPageView)
                },
                new MasterPageItem
                {
                    Id = 3,
                    Title = "Personalia",
                    IconSource  = "",
                    TargetType = typeof(NewsListPageView)
                },

            };
        }
    }
}
