   M S B A M L   `   `   `  ����I  ECosmeticHealth, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:CosmeticHealth.AddPagesCosmeticHealth.AddPages  5      /    )CosmeticHealth.AddPages.AddProblemSymptom   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:CosmeticHealth.AddPages     5        N� Title$  AddProblemSymptom��5	      .��5      �  � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $	��500 �6    � RowDefinitions 5   
   �� 5      �� 5      �� 5      .+�5   
   �� $��0��6   $��0��6   $��2��6-   $?��9Добавление Проблемы и Симптома��6A    
  Titles#��[  6j   �� 5   
   $��1��6   $��1��6!     	WinButton#��[ 6.   $��Center=�6Q   $��Подтвердить��6l   ��6�   �� *Accept+{�5      `� 5        	hasErrors `� 	Converter# [ 6   .1�5      ��  �� ElementName$
 prob��6    �� Path$ (Validation.HasError)�61   �� 5      $	 sym��6   $ (Validation.HasError)�60   5      5      �� 5   
   $��1��6   $��2��6!   #��[ 6.   $��Center=�6Q   ��6l   �� *Back+.��6�   Отмена6�   �� 5   
   $��1��6   $��0��6"   $��2��62   .+�5!      ��   	LoginPass#��[ 6   .��67   Проблема6A   �� 5"      -   5         ��Name$
 prob��5"   Y     Filters#��[ 6   ��68   �� *
Problems+ �� SelectedItem 6g   �� *ProblemSymptom.Problem+ �� ValidatesOnDataErrors$
 True����5#      �� 5$      .R�5%      �� �� 5&      �6"   �� *ProblemName+5'      5(      5*      �� 5+      
���  ����6)   �� $
 prob��$) #(Validation.Errors)[0].ErrorContent��� 5,      #��[ 6   .��67   Симптом6@   �� 5-      -   5        $	 sym��5-   Y   #��[ 6   ��68   �� *
Symptoms+ 6f   �� *ProblemSymptom.Symptom+$
 True����5.      �� 5/      .R�50      �� �� 51      �6"   �� *NameSymptom+52      53      55      �� 56      
���  ����6)   �� $	 sym��$) #(Validation.Errors)[0].ErrorContent�57      58      59      