   M S B A M L   `   `   `  ����I  ECosmeticHealth, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:CosmeticHealthCosmeticHealth  5      $    CosmeticHealth.ProductFullPage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:CosmeticHealth     5        N� Title$  ProductFullPage��5	       � DataContext 6   ��  �� Mode$ OneWay=� �� RelativeSource �� *Self+.��5      �  � ColumnDefinitions 5   
   �� 5      $	��300 �6   �� 5      $	��300 �6   �� 5      $��1* �6    � RowDefinitions 5   
   �� 5      �� 5      �� 5      .+�5   
   �� $��0��6   $��0��6    $	��300��6-   $	��300��6:   ��6F   �� *Product.Image+6i   �� 5   
   $��Bottom=�6   $��1��6+   $��0��68      	LoginPass#��[  6H   $��Center=�6k   .��6�   '%Наличие в магазинах:6�   �� 5   
   $��2��6   $��0��6    $	��300��61     Cosmetic#��[ 6�   $��Disabled=�6�   ��6A   �� *ProductShops+ �� SelectedItem 6f   �� *SelectedProductShop+��5      �� 5      .R�5      ��  �� CornerRadius$ 10��6   $��8q�6/   
�������._�5      �  	 Shops#��[ 6    5      �� 5   "   $	��100 �63   �� 5   "   $��1* �63   .+�5!      �� $��1��6)   .+�5"   "   ��   FullProduct#��[ 6,   �� 5#   &   �6*   �� *ShopNavigation.NameShop+�� 5$   &   5%   #   5&      5'      5(      5)      ��5+      �� 5,      .R�5-      � 5.      50      �� 51   
   $
��1100��6   $
��Left=�6   $ 10��69   $��8q�6K   
�������$��1��6s   $��0��6�   $��2��6�   ._�52      �� ���#e6e6fa.+�53      �� #��[ 6   �� 54      �6   �� *Product.ProductName+�� 55      �� 56      �6   �� **(Product.TypeNavigation.NameTypeOfProduct+�� 57      �� 58      �6   �� *#!Product.BrandNavigation.NameBrand+�� 59      Тип кожи: �� 5;      �6   �� *-+Product.TypeOfSkinNavigation.TypeOfSkinName+�� 5<      %#Способ применения: �� 5>      �6   �� *Product.HowUse+�� 5?      Описание: �� 5A      �6   �� *Product.Description+5B      �� 5C       �� Orientation$ 
Horizontal=�6   .+�5D      ��   Help#��[ 6   $
��Left=�6;   ��6V   �� *BackTo+.��5E      �� $��50��6    $��50��6,   $��/Images/back.png��67   5F      �� 5G      #��[ 6   $
��Left=�6;   ��6V   �� *
LinkSearch+.��5H      �� $��50��6    $��50��6,   $��/Images/url.png��67   5I      5J      5L      5M      �� 5N   
   $
��Left=�6   $ 10��6,   $��8q�6>   
�������$��2��6f   $��2��6v   ._�5O      �� ���#e6e6fa.+�5P      �� #��[ 6   �� 5Q      $�Состав:��6   �� 5R      �� 5S      �6   �� *	ListOfIng+5T      5V      5W      �� 5X   
   $	��300��6   $
��Left=�6   $ 10��68   $��8q�6J   
�������$��1��6r   $��2��6�   ._�5Y      �� ���#e6e6fa.+�5Z      �� #��[ 6   �� 5[      $�Проблемы:��6   �� 5\      �� 5]      �6   �� *HaveProblems+5^      5`      5a      5b      5c      