   M S B A M L   `   `   `  ����P  LShopProductManagerApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:ShopProductManagerAppShopProductManagerApp  5   	   &     ShopProductManagerApp.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   /local#clr-namespace:ShopProductManagerApp  5   	     � Title$+  %Управление товарами��5	   	   $	��450��5
   	   $	��800��5   	    � Icon$0 *pack://application:,,,/product-control.ico��5   	   .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $	��200 �6   �� 5      $	��150 �6   .+�5   
   A� $��0��6   $��40��6   $��40��6+   $��Right=�66   ��5      �� 5       �� ImageSource$ empty-avatar.jpg��6   5      �� 5!   
   -   5         ��Name$ Username��5!      $��Пользователь��6&   $��0��6:   $��1��6G   $��10 0 0 0q�6W   $
��Left=�5"      $��12(�6,   $��SemiBold"�6:   $��Center=�6P   �� 5$   
   -   5         ��Name$
 Exit��5$      $��0��6   $��3��6,   $��5q�6<   $��
Выход��6G   $��14(�5%       �� 5'   
   -   5         ��Name$ NameTextBox��5'      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Название��6'   $��1q�6Q   $��1��5(      $��0��6   $��5q�6*   $��14(�65   �� 5*   
   -   5        $ PriceTextBox��5*      $ Цена��6(   $��1q�6N   $��1��5+      $��1��6   $��5q�6*   $��14(�65   �� 5-   
   -   5        $ AddProductButton��5-      $��1��6+   $��2��68   $��5q�6H   $!��Добавить товар��6S   $��14(�5.   ,   &   System.Windows.Controls.DataGrid  50   
   -   5        	  Name$	 ProductList��50      $��2��6(   $��0��65   $��3��6E   $��5q�6Y   $��1q�51      
   AutoGenerateColumns
 .  $��14(�6=      Columns 52      0  *System.Windows.Controls.DataGridTextColumn  53      ,  &System.Windows.Controls.DataGridColumn   Header$# Название товара��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6>   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6I   �� *Name+  54      $ Цена��6%   $	 200 63    6?   �� *Price+56      57      58      