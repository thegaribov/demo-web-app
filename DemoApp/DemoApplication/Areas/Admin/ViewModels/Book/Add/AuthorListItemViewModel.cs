﻿namespace DemoApplication.Areas.Admin.ViewModels.Book.Add
{
    public class AuthorListItemViewModel
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public AuthorListItemViewModel(int id, string fullName)
        {
            Id = id;
            FullName = fullName;

        }
    }
}
