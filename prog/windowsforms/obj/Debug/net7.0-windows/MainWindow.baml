   M S B A M L   `   `   `  ����  windowsforms    TaskManager.MainWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � Title$  Task Manager��5   	   $	��450��6   $	��600��6+   .��5      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ TasksDataGrid��5
         AutoGenerateColumns$ False��6H   ��6*   �� *Tasks+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 	Task Name��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 68   �� *Name+  5      $ Description��6%    6:   �� *Description+  5      $ Category��6%    67   �� *
Category+5      �� 5   
   -   5         ��Name$ AddTaskButton��5      $��Add Task��6(   6;   �� 5   
   -   5        $ EditTaskButton��5      $��	Edit Task��6)   6=   �� 5   
   -   5        $ DeleteTaskButton��5      $��Delete Task��6+   6A   �� 5   
   -   5         ��Name$ CategoryComboBox��5       �� DisplayMemberPath$
 Name��6P   	 �� SelectedValuePath$	 Id��6i   ��6-   �� *
Categories+6i   �� 5   
   -   5        $ AddCategoryButton��5      $��Add Category��6,   6C   �� 5   
   -   5        $ EditCategoryButton��5      $��Edit Category��6-   6E   �� 5   
   -   5        $ DeleteCategoryButton��5      $��Delete Category��6/   6I   �� 5   
   
 �� Orientation$
 
Horizontal=�6   .+�5      �� -	   5        $ 
SaveButton��5      $
��Save��6)   68   �� 5      -
   5        $ 
LoadButton��5      $
��Load��6)   68   �� 5       -   5        $ ExportMarkdownButton��5       $��Export to Markdown��64   6Q   5!      5"      5#      