   M S B A M L   `   `   `  ����G  CBookStoreGUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:BookStoreGUIBookStoreGUI  5   	   %    BookStoreGUI.OrderDetailsWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:BookStoreGUI     5   	     � Title$  OrderDetailsWindow��5   	   $	��450��6$   $	��920��61   .��5	      � .+�5
   
   �� -   5         ��Name$ orderDetailsListView��5
       �� SelectionMode$ Single=�5      $��29,57,29,35q�66   ��6   ��  �� View 5      �� 5      .P�5      ��  �� Width$	 160��6%   $
��Date��61    �� DisplayMemberBinding 5      �� *Date+�� 5      $ 80��6%   $
��ISBN��60    5      �� *BookID+�� 5      $	 440��6%   $��Title��61    5      �� *	BookTitle+�� 5      $ 60��6%   $��Quantity��60    5      �� *
Quantity+�� 5      $ 80��6%   $��Subtotal��60    5      �� *
SubTotal+5      5      �� 5   
   $��Order History��6   $	��250��6(   $
��Left=�64   $��	29,10,0,0q�6O   $	��Top=�6b    J� RenderTransformOrigin$ 0.395,-0.343&�6z   $
��Bold"�6�   $��24(�6�   5      5      