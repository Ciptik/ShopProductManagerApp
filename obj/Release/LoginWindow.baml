   M S B A M L   `   `   `  ���� P  LShopProductManagerApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:ShopProductManagerAppShopProductManagerApp  '    !ShopProductManagerApp.LoginWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  /local#clr-namespace:ShopProductManagerApp    � Title$  Вход��$	��700��$	��400�� � AllowsTransparency .  � WindowStyle$
 None=� � WindowStartupLocation$ CenterScreen=�    MaterialDesignDarkBackground#���   ��Z� .��#  MaterialDesignThemes.Wpf.Card     UniformCornerRadius$ 10Q�  MaterialDesignPaper#���  .��� $��20q� � RowDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto � � ColumnDefinitions �� $��* �.+��� -    ��Name$ CloseButton��$��0��$��0��$��X��$��30��$��30��$��0q�$��0q�$��Right=�$	��Top=�
���  ��
�������$
��Bold"�+  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 10���� $��logo.png��$��1��$��0��$	��150��$��	0 20 0 40q��� $&�� Добро пожаловать!��$��2��$��0��$��0 0 0 5q�$��Center=�$��28(�$
��Bold"��� $&�� Войдите в аккаунт��$��3��$��0��$��0 0 0 30q�$��Center=�$��24(�$��SemiBold"��� -   	 ��Name$	 UsernameTextBox��$��4��$��
20 0 20 15q�$��18(�)  #MaterialDesignThemes.Wpf.HintAssist
   Hint$%
 Имя пользователя��$��3q�  MaterialDesignDivider#���   ! MaterialDesignOutlinedTextBox#��[ G� -    G�Name$ PasswordBox��$��5��$��
20 0 20 15q�$��18(�$
 Пароль��$��3q�#���   % !MaterialDesignOutlinedPasswordBox#��[ �� -   $ LoginButton��$��6��$��
20 0 20 15q�$��60��$
��Bold"�$��20(�$��ВХОД��$ 10��  MaterialDesignRaisedButton#��[ �� -   $ OpenRegisterButton��$��7��$��	20 0 20 0q�$��60��$��SemiBold"�$��20(�$%��Создайте аккаунт��$ 10��  MaterialDesignFlatButton#��[ 