﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WPF_Project.Models
{
    public class BoardTask
    {
        [Key]
        public Guid ID { get; set; }
        public string Title { get; set; } = "New Task";
        public string Description { get; set; } = "";
        public BoardTaskPriority Priority { get; set; } = BoardTaskPriority.Mid;

        public ICollection<Tag>? Tags { get; set; }
        public ICollection<SubTask>? SubTasks { get; set; }
        public int Column_ID { get; set; }
        public BoardColumn Column { get; set; }

        public BoardTaskVM ToVM()
            => new BoardTaskVM
                {
                    ID = this.ID,
                    Title = this.Title,
                    Description = this.Description,
                    Priority = this.Priority,
                    Tags = this.Tags,
                    SubTasks = this.SubTasks,
                    Column_ID = this.Column_ID,
                    Column = this.Column
                };
    }
    public enum BoardTaskPriority { Low, Mid, High }
    public static class BoardTaskPriority_Ext 
    {
        public static Color ToColor(this BoardTaskPriority self) => self switch {
            BoardTaskPriority.Low  => Color.FromRgb(0, 255, 0),    // Green
            BoardTaskPriority.Mid  => Color.FromRgb(255, 255, 0), // Yellow
            BoardTaskPriority.High => Color.FromRgb(255, 0, 0),  // Red
            _ => Color.FromRgb(255, 255, 255)
        };
        // public static BoardTaskPriority FromColor(Color color) => color switch {
        //       => Color.FromRgb(0, 255, 0),
        //     BoardTaskPriority.Mid  => Color.FromRgb(0, 255, 255),
        //     BoardTaskPriority.High => Color.FromRgb(255, 0, 0),
        //     _ => Color.FromRgb(255, 255, 255)
        // };
    }
}