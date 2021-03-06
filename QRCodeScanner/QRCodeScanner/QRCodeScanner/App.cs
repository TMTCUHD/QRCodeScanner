﻿using System;
using System.Diagnostics;
using Xamarin.Forms;
using ZXing;
using ZXing.Mobile;

namespace QRCodeScanner
{
  public class App : Application
  {
    public App()
    {
      Button scanButton = new Button
      {
        Text = "Scan QR Code"
      };
      scanButton.Clicked += ScanButtonOnClicked;

      MainPage = new ContentPage
      {
        Content = new StackLayout
        {
          VerticalOptions = LayoutOptions.Center,
          Children = {
            scanButton
          }
        }
      };            
    }

    private async void ScanButtonOnClicked(object sender, EventArgs eventArgs)
    {
      MobileBarcodeScanner scanner = new MobileBarcodeScanner();

      Result result = await scanner.Scan();
      if (result != null)
      {
        SecurityService securityService = new SecurityService();
        string decrypted = securityService.Decrypt(result.Text, SecurityService.Key);
        await MainPage.DisplayAlert("Result", "Scanned Barcode: " + decrypted, "OK");
      }
    }

    protected override void OnStart()
    {
      // Handle when your app starts
    }

    protected override void OnSleep()
    {
      // Handle when your app sleeps
    }

    protected override void OnResume()
    {
      // Handle when your app resumes
    }
  }
}
