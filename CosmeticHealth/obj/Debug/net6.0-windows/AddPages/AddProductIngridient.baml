   M S B A M L   `   `   `  ����I  ECosmeticHealth, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:CosmeticHealth.AddPagesCosmeticHealth.AddPages  5      2    ,CosmeticHealth.AddPages.AddProductIngridient   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:CosmeticHealth.AddPages     5        N� Title$  AddProductIngridient��5	      .��5      �  � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $	��500 �6    � RowDefinitions 5   
   �� 5      �� 5      �� 5      .+�5   
   �� $��0��6   $��0��6   $��2��6-   $M��GРедактирование Продукта и Ингредиента��6A    
  Titles#��[  6q   �� 5   
   $��1��6   $��1��6!     	WinButton#��[ 6.   $��Center=�6Q   $��Подтвердить��6�   ��6l   �� *Accept+{�5      `� 5        	hasErrors `� 	Converter# [ 6   .1�5      ��  �� ElementName$
 prod��6    �� Path$ (Validation.HasError)�61   �� 5      $	 ing��6   $ (Validation.HasError)�60   �� 5      $
 proc��6   $ (Validation.HasError)�61   5      5      �� 5   
   $��1��6   $��2��6!   #��[ 6.   $��Center=�6Q   ��6l   �� *Back+.��6�   Отмена6�   �� 5    
   $��1��6   $��0��6"   $��2��62   .+�5"      ��   	LoginPass#��[ 6   .��67   Продукт6@   �� 5#      -   5         ��Name$
 prod��5#   8     Filters#��[ 6   ��6F   �� *
Products+ �� SelectedItem 6g   �� *ProductIngredient.Product+ �� ValidatesOnDataErrors$
 True����5$      �� 5%      .R�5&      �� �� 5'      �6"   �� *ProductName+5(      5)      5+      �� 5,      
���  ����6)   �� $
 prod��$) #(Validation.Errors)[0].ErrorContent��� 5-      #��[ 6   .��67   Ингредиент6C   �� 5.      -   5        $	 ing��5.   8   #��[ 6   ��6E   �� *Ingredients+ 6i   �� *ProductIngredient.Ingredient+$
 True����5/      �� 50      .R�51      �� �� 52      �6"   �� *NameIngredient+53      54      56      �� 57      
���  ����6)   �� $	 ing��$) #(Validation.Errors)[0].ErrorContent��� 58      #��[ 6   .��67   Процент6@   �� 59      -   5        	 ��Name$
	 proc��59   7     LogPass#��[ 6   ��6E   �� *ProductIngredient.Procent+$
 True��
 �� UpdateSourceTrigger$
 PropertyChanged=�6�   �� 5:      
���  ����6)   �� $
 proc��$) #(Validation.Errors)[0].ErrorContent�5;      5<      5=      