   M S B A M L   `   `   `  ����G  CBookStoreGUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:BookStoreGUIBookStoreGUI  5   	   +    %BookStoreGUI.AddDeliveryAddressDialog   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:BookStoreGUI     5   	     � Title$  Add Delivery Address��5   	   $��205.128��6&   $��334.615��67   .��5	      � $��0,0,-0.4,-0.8q�6    J� RenderTransformOrigin$ 0.491,0.589&�6"    � ColumnDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5       � RowDefinitions 5   
   �� 5      $��28 �6   �� 5      $��28 �6   �� 5      $��28 �6   �� 5      $��76 �6   �� 5      $
��Auto �6   �� 5      $��0* �6   .+�5   
   �� $��0��6   $��0��6    $��2,2,2,2q�6-   .��6>   City:6E   �� 5   
   -   5        $��cityTextBox��5      $��1��6%   $��0��5      $��2,0,2.4,1.8q�6   $��2��64   {�. $��Bottom=�6Y   $��Bottom=�6{   $��23��6�   �� 5   
   $��0��6   $��1��6    $��2,2,2,2q�6-   .��6>   State:6F   �� 5   
   -   5        $��stateTextBox��5      $��1��6&   $��1��5      $��2,0,2.4,1.6q�6   $��2��64   {�. $��Bottom=�6Y   $��Bottom=�6{   $��23��6�   �� 5   
   $��0��6   $��2��6    $��2,2.2q�6-   .��6<   
Address:6F   �� 5   
   -   5        $��addressTextBox��5      $��1��6(   $��2��5      $��2,0,2.4,2.4q�6   $��2��64   {�. $��Bottom=�6Y   $��Bottom=�6{   $��23��6�   �� 5    
   $��2��6   $��3��5!       �� Orientation$ 
Horizontal=�6"   $��Right=�5"      $��
0,10,71,18q�61   $	��187��6E   .+�5#      �� -   5        $��okButton��5#       �� 	IsDefault . $��80��5$      $��12,10,5,17.8q�6#   $��23��69   $��23��6H   .��6V   OK6Z   �� 5%      -   5        $��cancelButton��5%       �� IsCancel . $��80��5&      $��5,10,5,17.8q�6#   $��23��68   $��23��6G   .��6U   Cancel6]   5'      5(      5)      