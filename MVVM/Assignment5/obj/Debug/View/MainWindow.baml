   M S B A M L   `   `   `  ����F  BAssignment5, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Assignment5Assignment5  5   	   !    Assignment5.View.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Assignment5     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��700��6)   .��5	      � .+�5
   
   �� -   5         ��Name$ button1��5
      $��Sort by Last Name��6"      buttonStyle_LastName#��[  6>   ��6l   ��  �� Path$ SortByLastNameDesc��� 5   
   -   5        $ button2��5      $��Sort by Pay Amount��6"     buttonStyle_PayAmount#��[ 6?   ��6n   �� $ SortBySalaryEmp��� 5   
   -   5        $ button3��5      $��Sort by SSN��6"     buttonStyle_SSN#��[ 68   ��6a   �� $ 	SortBySSN��� 5   
   -   5         ��Name$ label��5      $��Sorting Order��6     
labelStyle#��[ 67   �� 5   
   -   5         ��Name$ comboBox��5      $	��118��6     
comboStyle#��[ 61    �� DisplayMemberPath$ DisplayName��5      ��5   U   �� *Sort+ �� SelectedItem 5   3   �� *SelectedOrder+ �� UpdateSourceTrigger$ PropertyChanged=��� 5   
   -   5        $ button��5      $��Reload��6!     buttonStyle_reload#��[ 62   ��6^   �� $ 	Reloadbtn�&   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dataGrid��5      	   AutoGenerateColumns	 .  $	��200��5   /   $	��650��6<   $
��Left=�6H   $��
10,151,0,0q�6c   $	��Top=�6w   ��5   %   �� *
SortedList+
   Columns
 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 
First Name��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 69   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6C   �� *	FirstName+  5      $ 	Last Name��6%   $ * 68    6B   �� *
LastName+  5      $ Social Security Number��6%   $ * 6E    6O   �� *SocialSecurityNumber+  5      $ 
Pay Amount��6%   $ * 69    6C   �� *	PayAmount+5      5      5      