   M S B A M L   `   `   `  ����G  CBookStoreGUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:BookStoreGUIBookStoreGUI  5   	        BookStoreGUI.BookAddWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:BookStoreGUI     5   	     � Title$  Create New Book��5   	   $	��300��6!   $	��300��6.   .��5	      � $��10q�6    � ColumnDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6   $��0��6    $��2,2,2,2q�6-   .��6>   ISBN:6E   �� 5   
   -   5        $
��isbn��5      $��1��6   $��0��5      $��0,0,2.4,1.8q�6   $��2��64   $��Bottom=�6H   $��Bottom=�6j   $��23��6�   �� 5   
   $��0��6   $��1��6    $��2,2,2,2q�6-   .��6>   Title:6F   �� 5   
   -   5        $��title��5      $��1��6   $��1��5      $��0,0,2.4,1.6q�6   $��2��64   $��Bottom=�6H   $��Bottom=�6j   $��23��6�   �� 5   
   $��0��6   $��2��6    $��2,2.2q�6-   .��6<   Price:6D   �� 5   
   -   5        $��price��5      $��1��6   $��2��5       $��0,0,2.4,2.4q�6   $��2��64   $��Bottom=�6H   $��Bottom=�6j   $��23��6�   �� 5!   
   $��0��6   $��3��6    $��2,2,2,2q�6-   .��6?   	Author:6H   �� 5"   
   -   5        $��author��5"      $��1��6    $��3��5#      $��0,0,2,0q�6   $��Bottom=�60   $��Center=�6R   $��23��6m   �� 5$   
   $��0��6   $��4��6    $��2,2,2,2q�6-   .��6?   Year:6F   �� 5%   
   -   5        $
��year��5%      $��1��6   $��4��5&      $��0,0,2,0q�6   $��Bottom=�60   $��Center=�6R   $��23��6m   $��2��6y   �� 5'   
   $��5��6   $��0��6   $��	Category:��6-   �� 5(   
   -   5         ��Name$ categoriesComboBox��5(   8   $��5��6   $ �� IsSynchronizedWithCurrentItem$
 TrueY�6T    �� DisplayMemberPath$
 Name��6�   $��23��6�   $��0,2,2,1q�6�   $��2��6�   ��6    ��  �� SelectedValue 6y   �� *
CategoryID+ �� Mode$ TwoWay=���5)      �� 5*      .R�5+      $� 5,      5.      �� 5/   
   $��1��6   $��6��50       �� Orientation$ 
Horizontal=�6"   $��Right=�51      $��0,10,2,0q�61   .+�52      �� -   5        $��okButton��52      $��0,0,10,0q�6%   	 �� 	IsDefault	 . $��80��53      $��23��6#   $��23��62   .��6W   Create6_   �� 54      -   5        $��cancelButton��54      
 �� IsCancel
 . $��80��55      $��23��6#   $��23��62   .��6@   Cancel6H   56      57      58      