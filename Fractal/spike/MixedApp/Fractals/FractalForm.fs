﻿namespace Fractals

open FractalFunctions
open System.Drawing
open System.Windows.Forms

module FractalForm =

    let formWidth, formHeight = 1000, 800
    let imageCentre = float formWidth/2.0

    let image = new Bitmap(formWidth, formHeight)
    let graphics = Graphics.FromImage(image)

    let getForm title image =
        let form = new Form(Text=title, Width=formWidth, Height=formHeight)
        let box = new PictureBox(BackColor=Color.White, Dock=DockStyle.Fill)
        box.Image <- image
        form.Controls.Add(box)
        form

    let line x y angle length width colour =
        drawLine graphics (colour |> brush) x y angle length width ((double)formHeight)

    let circle x y radius colour =
        drawCircle graphics (colour |> brush) x y radius (float formHeight)