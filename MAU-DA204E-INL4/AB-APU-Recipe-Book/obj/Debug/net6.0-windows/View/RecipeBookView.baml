   M S B A M L   `   `   `  ����M  IAB-APU-Recipe-Book, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:AB_APU_Recipe_Book.ViewAB_APU_Recipe_Book.View  5      K*clr-namespace:AB_APU_Recipe_Book.ViewModelAB_APU_Recipe_Book.ViewModel  5      ,    &AB_APU_Recipe_Book.View.RecipeBookView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      ;i+http://schemas.microsoft.com/xaml/behaviors      5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:AB_APU_Recipe_Book.View     5      @	viewmodel*clr-namespace:AB_APU_Recipe_Book.ViewModel     5      
�������.��5      �   � ColumnDefinitions  5   
   �� 5      $��* �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��* �6   .+�5   
   �� $��5q�63   ��6   �� *GroupBoxName+��6>   �� *GroupBoxBackground+.��5      �   5      �� 5      $
��Auto �6'   �� 5      $��* �6'   �� 5      $��* �6'    5      �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5       $��* �6$   �� 5!      $
��Auto �6$   .+�5$      �� $��Name of recipe��6   $��0��61   $��5q�6>   �� 5%      $��0��6   $��1��6'   $��5q�67   $��2��6B   ��6V   �� *CurrentRecipe.Name+ �� UpdateSourceTrigger$ PropertyChanged=��� 5&      $��Category��6   $��1��6+   $��5q�68   �� 5'      $��1��6   $��1��6(   $��5q�68    �� 
IsEditable$ False��6C   ��6V   �� *
Categories+$ PropertyChanged=� �� SelectedValue 6�   �� *CurrentRecipe.Category+�� 5(      $��Add ingredients��6   $��1��63   $��2��6@   $��5q�6P   ��6[   �� *AddIngredients+�� 5)       �� TextWrapping$
 Wrap=�6    �� AcceptsReturn$
 True��6.   " �� VerticalScrollBarVisibility$ Visible=�6C   $��2��6i   $��0��6v   $��3��6�   $��5q�6�   ��6�   �� *CurrentRecipe.Description+$ PropertyChanged=��� 5*      $��
Add recipe��6   $��3��6.   $��0��6;   $��3��6K   $��5q�6_   ��6j   �� *	AddRecipe+5+      5,      � 5-   
   $��1��6     5.      �� 5/      $��* �6#    51      �� 52      $��* �6    �� 53      $
��Auto �6    �� 54      $
��Auto �6    .+�56      &   System.Windows.Controls.DataGrid  $��0��6   $��5q�6$      AutoGenerateColumns$ False��6/   	   CanUserAddRows$	 False��6K   
   
IsReadOnly$

 True��6b   ��6t   �� *	Recipes+ �� SelectedItem 6�   �� *SavedRecipeSelection+ J� InputBindings 57      d� 58       d� Gesture$ LeftDoubleClicka�6#    �� Command 6=   �� *LeftDoubleClick+   Columns 5:      0  *System.Windows.Controls.DataGridTextColumn  5;      ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6P   1  +System.Windows.Controls.DataGridBoundColumn   Binding 67   �� *Name+6P     5<      $ Category��6)   $
 Auto 6X    6;   �� *
Category+6X     5=      $ No. of ingredients��6)   $
 Auto 6i    6E   �� *IngredientCount+6i   5?      �� 5@      $��1��6    �� Orientation$ 
Horizontal=�6&   $��Center=�6?   .+�5A      �� $
��Edit��6   $��5q�6(   $	��100��6T   ��63   �� *EditSelected+6T   �� 5B      $��Delete��6   $��5q�6*   $	��100��6P   ��65   �� *Delete+6P   �� 5C      $��Clear Selection��6   $��5q�63   $	��100��6a   ��6>   �� *ClearSelection+6a   5D      �� 5E      $��2��6   $��Center=�6!   $G��ADouble-click on an item for ingredients and cooking instructions!��6>   5F      5I      5J      