﻿using AppFramework.Domain;
using LMS.Domain.BookAgg;

namespace LMS.Domain.BookCategoryAgg;

public class BookCategory : BaseEntity
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public List<Book> Books { get; private set; }

    public BookCategory()
    {
        Books = new List<Book>();
    }

    public BookCategory(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public void Edit(string name, string description)
    {
        Name = name;
        Description = description;
    }
}
