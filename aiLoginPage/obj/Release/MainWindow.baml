   M S B A M L   `   `   `  ����   BookStoreGUI    BookStoreGUI.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     -     � Title$!  BookStore Management System��$	��650��$	��550��.���  � ColumnDefinitions �� .+��� -    ��Name$ 
LayoutRoot�� �� Orientation$ Vertical=�$
��Left=�$	��600��$
��auto�� � DataContext �� .+��� $��30��$	��505��.+��� -   $��New User��$��80��$��	150,4,0,2q�$��25���� -    ��Name$ 
myComboBox��$��2��$��2��$��
75,-25,0,0q�$	��Top=�$��24��$
��Left=�$	��123��.@��� -   $��Option1��$��View User Info���� -   $��Option2��$��Edit User Info���� -   $��Option3��$��Change Password���� -   $��Option4��$��Delete Account���� $��User Profile: ��$��-410,-25,0,0q�$��94���� -	   $��Logout��$��80��$��350,-30,0,0q�$��25���� $ 
Horizontal=�$
��Left=�$��15, 10, 0, 0q�.+��� $��Categories:��$��0,0,0,0q��� -
   $ categoriesComboBox��$ �� IsSynchronizedWithCurrentItem$
 TrueY� �� DisplayMemberPath$
 Name��$��23��$��0q�$	��200������  �� SelectedValue �� *
CategoryID+	 �� Mode$	 TwoWay=����� .R�$� �� -   
 ��Name$
 loginButton��$��Login��$��25��$��75��$��28,2,0,0q��� -   $
 
exitButton��$
��Exit��$��25��$��75��$��20,2,0,0q��� $ 
Horizontal=�$
��Left=�$��15,8,0,0q�.+��� $��Search:��$��0,0,0,0q��� -    ��Name$ searchQuery��$	��200���� -   $
 Search��$��Search��$��25��$��75��$��28,0,0,0q��� $��
Search By:��$��15,0,0,0q��� -   $ searchTypeCombobox��$��10,0,0,0q�.@��� .��Title�� .��ISBN�� .��Author�� .��Price�� .��Year�� $ 
Horizontal=�$
��Left=�$��	15,10,0,0q�.+��� $��Books:���� -   $	��New��$��	10,0,10,0q�$��0,0,10,0q��� -   $��Delete��$��	10,0,10,0q��� $ 
Horizontal=�$
��Left=�$��	15,10,0,0q�.+��� $��Categories:���� -   $��newCategoryName��$	��104��$��0,0,5,0q��� -   $	��New��$��	10,0,10,0q�$��0,0,10,0q��� -   $ categoryToDelete��$
 Name��$��0,0,5,0q�$	��200������ .R�$� �� -   $��Delete��$��	10,0,10,0q�$��0,0,10,0q�&   System.Windows.Controls.DataGrid  -     Name$ productsDataGrid��   AutoGenerateColumns .  $	��168��   RowDetailsVisibilityMode$ VisibleWhenSelected=�$	��490��$
��Left=�$��20,10,20,10q�   SelectionMode$ Single=�   
IsReadOnly .  �� *ISBN+$	 TwoWay=����� *
dsCat_Book+   Columns 0  *System.Windows.Controls.DataGridTextColumn  -   titleColumn��,  &System.Windows.Controls.DataGridColumn   Header$ Title��   Width5  /System.Windows.Controls.DataGridLengthConverter$	 50* 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Title+  -   authorColumn��$ Author��$	 18*  �� *Author+  -   priceColumn��$ Price��$	 12*    CanUserSort .   �� *Price+  -   
yearColumn��$
 Year��$ 8*  �� *Year+�� $ Vertical=�.+��� $
��Auto=�.���� -    ��Name$ orderListView��$	��150��$	��490�� �� SelectionMode$ Single=�����  �� View �� .P���  �� Width$ 80��$
��ISBN�� �� DisplayMemberBinding �� *BookID+�� $	 285��$��Title�� �� *	BookTitle+�� $ 60��$��Quantity�� �� *
Quantity+�� $ 60��$��Subtotal�� �� *
SubTotal+�� $ 
Horizontal=�$��Center=�$��10q�$��26��$	��518�� J� RenderTransformOrigin$ 0.607,0.538&�.+��� -   $
 	addButton��$��25��$��90��$��Add Book��$��5,0,0,0q�$��45��$ 0.5,0.5&�z�V� .~��� �� ��  �� Angle$ -0.549Q�T� �� -   $
 removeButton��$��25��$��80��$��Remove Book��$��5,0,0,0q��� -   $
 addPayButton��$��25��$��80��$��Address/Payment��$��5,0,0,0q�$	��102���� -   $
 orderDetails��$��Order Details��$��5,0,5,0q�$	��102���� -    $
 checkoutOrderButton��$��25��$��80��$��Proceed to Checkout��$	��115��$��0,0,5,0q��� $��Bottom=�$��Stretch=�.@��� -!    ��Name$ statusTextBlock���� $1�+Please login before proceeding to checkout.��