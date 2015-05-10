﻿using System;
using UnityEngine;

namespace AffinityUI
{
	/// <summary>
	/// A masked password field.
	/// </summary>
	public class PasswordField : ContentControl<PasswordField>
	{
        BindableProperty<PasswordField, string> _password;

		/// <summary>
		/// Gets or sets the mask character, used only by GUI and GUILayout contexts.
		/// </summary>
		/// <value>The mask.</value>
		public char Mask { get; set; }

		/// <summary>
		/// Gets or sets the maximum password length, used only by GUI and GUILayout contexts.
		/// </summary>
		/// <value>The length of the max.</value>
		public int MaxLength { get; set; }

        public BindableProperty<PasswordField, string> Password()
        {
            return _password;
        }

        public PasswordField Password(string text)
        {
            _password.Value = text;
            return this;
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="PasswordField"/> class.
		/// </summary>
		public PasswordField()
			: base()
		{
			Mask = '*';
			MaxLength = Int32.MaxValue;
            Style(() => GUI.skin.textField);
            _password = new BindableProperty<PasswordField, string>(this, string.Empty);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="PasswordField"/> class.
		/// </summary>
		/// <param name="label">The label text.</param>
		public PasswordField(string label)
			: this()
		{
            Label(label);
		}

		/// <summary>
		/// Adds an event handler for password change.
		/// </summary>
		/// <param name="handler">The handler.</param>
		/// <returns>this instance</returns>
		public PasswordField OnPasswordChanged(PropertyChangedEventHandler<PasswordField, string> handler)
		{
			_password.PropertyChanged += handler;
			return this;
		}

		/// <summary>
		/// Called when layout is done using GUI.
		/// </summary>
		protected override void Layout_GUI()
		{
            Password(GUI.PasswordField(Position(), Password(), Mask, MaxLength, Style()));
		}

		/// <summary>
		/// Called when layout is done using GUILayout.
		/// </summary>
		protected override void Layout_GUILayout()
		{
            Password(GUILayout.PasswordField(Password(), Mask, MaxLength, Style(), LayoutOptions()));
		}
	}
}