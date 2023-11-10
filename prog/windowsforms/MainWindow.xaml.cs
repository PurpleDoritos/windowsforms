using System;
using System.Linq;
using System.Windows;
using Microsoft.Win32;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;   // ObservableCollection


public partial class MyTaskViewModel
{
    public partial class MainWindow : Window
    {
        private TaskViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new TaskViewModel();
            DataContext = _viewModel;
        }

        // Other event handlers and methods...
    }

    private void AddTaskButton_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            TaskItem newTask = new TaskItem
            {
                Title = TitleTextBox.Text,
                Description = DescriptionTextBox.Text,
                DueDate = DatePicker.SelectedDate ?? DateTime.Now,
                IsCompleted = CompletedCheckBox.IsChecked ?? false,
                Labels = LabelsTextBox.Text.Split(',').ToList(),
                Priority = int.Parse(PriorityTextBox.Text),
            };

            _viewModel.AddTask(newTask);

            // Clear input fields
            TitleTextBox.Clear();
            DescriptionTextBox.Clear();
            DatePicker.SelectedDate = DateTime.Now;
            CompletedCheckBox.IsChecked = false;
            LabelsTextBox.Clear();
            PriorityTextBox.Clear();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error adding task: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private void DeleteTaskButton_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            TaskItem selectedTask = (TaskItem)TasksDataGrid.SelectedItem;
            if (selectedTask != null)
            {
                _viewModel.DeleteTask(selectedTask);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error deleting task: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private void SaveButton_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV Files (*.csv)|*.csv";

            if (saveFileDialog.ShowDialog() == true)
            {
                string filePath = saveFileDialog.FileName;
                _viewModel.SaveTasksToFile(filePath);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error saving tasks: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private void LoadButton_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV Files (*.csv)|*.csv";

            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                _viewModel.LoadTasksFromFile(filePath);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading tasks: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private void ExportMarkdownButton_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Markdown Files (*.md)|*.md"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                string filePath = saveFileDialog.FileName;

                _viewModel.ExportTasksToMarkdown(filePath);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error exporting tasks: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    public class TaskItem
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; }
        public List<string>? Labels { get; set; }
        public int Priority { get; set; }
    }

    public class TaskViewModel
    {
        public ObservableCollection<TaskItem> Tasks { get; set; }

        public TaskViewModel()
        {
            Tasks = new ObservableCollection<TaskItem>();
        }

        public void AddTask(TaskItem task)
        {
            Tasks.Add(task);
        }

        public void DeleteTask(TaskItem task)
        {
            Tasks.Remove(task);
        }

        public void SaveTasksToFile(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (TaskItem task in Tasks)
                {
                    writer.WriteLine($"{task.Title},{task.Description},{task.DueDate},{task.IsCompleted},{string.Join(",", task.Labels ?? new List<string>())},{task.Priority}");
                }
            }
        }

        public void LoadTasksFromFile(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] values = line.Split(',');
                    TaskItem task = new TaskItem
                    {
                        Title = values[0],
                        Description = values[1],
                        DueDate = DateTime.Parse(values[2]),
                        IsCompleted = bool.Parse(values[3]),
                        Labels = values.Length > 4 && values[4] != null ? values[4].Split(',').ToList() : new List<string>(),
                        Priority = int.Parse(values[5]),
                    };
                    AddTask(task);
                }
            }
        }

        public void ExportTasksToMarkdown(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (TaskItem task in Tasks)
                {
                    writer.WriteLine($"## {task.Title}");
                    writer.WriteLine();
                    writer.WriteLine($"{task.Description}");
                    writer.WriteLine();
                    writer.WriteLine($"**Due Date:** {task.DueDate.ToShortDateString()}");
                    writer.WriteLine();
                    writer.WriteLine($"**Priority:** {task.Priority}");
                    writer.WriteLine();
                    writer.WriteLine($"**Labels:** {string.Join(", ", task.Labels)}");
                    writer.WriteLine();
                    writer.WriteLine("---");
                    writer.WriteLine();
                }
            }
        }
    }




}

