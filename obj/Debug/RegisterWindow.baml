   M S B A M L   `   `   `  ����P  LShopProductManagerApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:ShopProductManagerAppShopProductManagerApp  5   	   *    $ShopProductManagerApp.RegisterWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   /local#clr-namespace:ShopProductManagerApp  5   	     � Title$  Вход��5	   	   $	��700��5
   	   $	��400��5   	    � AllowsTransparency .  � WindowStyle$
 None=�5   	    � WindowStartupLocation$ CenterScreen=�5   	       MaterialDesignDarkBackground#���   5   	   ��5   	   Z� .��5      #  MaterialDesignThemes.Wpf.Card     UniformCornerRadius$ 10Q�6     MaterialDesignPaper#���  63   .��5   
   � $��20q�6    � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6     � ColumnDefinitions 5      �� 5       $��* �6#   .+�5#      �� -   5         ��Name$ CloseButton��5#      $��0��6*   $��0��67   $��X��6G   $��30��6S   $��30��6^   $��0q�5$      $��0q�6   $��Right=�6(   $	��Top=�6D   
���  ��
�������$
��Bold"�5%   $   +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 10��66   6d   �� 5'      $��logo.png��6   $��1��6&   $��0��63   $	��150��6C   $��	0 20 0 40q�6P   �� 5)      $��Вы новичок?��6   $��2��6+   $��0��68   $��0 0 0 5q�6H   $��Center=�5*      $��28(�6.   $
��Bold"�6<   �� 5,      $1��+Создайте новый аккаунт!��6   $��3��67   $��0��6D   $��0 0 0 30q�6T   $��Center=�5-      $��24(�6.   $��SemiBold"�6<   �� 5/      -   5        	 ��Name$	 UsernameTextBox��5/      $��4��6/   $��
20 0 20 15q�6<   $��18(�6P   )  #MaterialDesignThemes.Wpf.HintAssist
   Hint$%
 Имя пользователя��50      $��3q�6C     MaterialDesignDivider#���  51       ! MaterialDesignOutlinedTextBox#��[ 52      G� 54      -   5         G�Name$ PasswordBox��54      $��5��6/   $��
20 0 20 15q�6<   $��18(�6P   $
 Пароль��55      $��3q�69   #���  56       % !MaterialDesignOutlinedPasswordBox#��[ 57      �� 59      -   5        $ RegisterButton��59      $��6��6-   $��
20 0 20 15q�6:   $��60��6N   $
��Bold"�6Z   $��20(�5:      $��СОЗДАТЬ��6   $ 10��5;        MaterialDesignRaisedButton#��[ 5<      �� 5>      -   5        $ OpenLoginButton��5>      $��7��6.   $��	20 0 20 0q�6;   $��60��6N   $��SemiBold"�6Z   $��20(�5?      $,��&Войти в существующий��6   $ 10��5@        MaterialDesignFlatButton#��[ 5A      5B      5C      5D      