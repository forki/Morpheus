﻿namespace Fractals

open FractalFunctions

// Taken from https://github.com/relentless/FractalFun
type Leaf(parameters: IParameters) =

    let branchAngle = 0.25
    let lengthMultiplier = 1.0/2.0
    let widthModifier = -0.6
    let startWidth = 3.0
    let startLength = 500.0
    let numBranches = 6

    let startColour = (0, 80, 0)
    let endColour = (0, 180, 0)

    let numSteps = int (startWidth / -widthModifier)
    let step = colourStep startColour endColour numSteps

    let rec endpoints x y length angle iteration = seq {
        let segLength = length / float numBranches
        yield endpoint x y (pi*angle) (segLength*float iteration)
        if iteration < numBranches then
            yield! endpoints x y angle length (iteration+1)
    }

    let rec branch (drawings: IFractalDrawing) x y length width colour angle =
        if width > 0.0 then
            let angleDegrees = (pi*angle)
            drawings.Line x y angleDegrees length width colour

            endpoints x y angle length 0
            |> Seq.iteri (fun i (nextX, nextY) ->
                let stageLengthMultiplier = 1.0 - (0.5/float numBranches*float i)
                let stageWidthMultiplier = 1.0 - (0.1/float numBranches*float i)
                branch drawings nextX nextY (length*lengthMultiplier*stageLengthMultiplier) (width*stageWidthMultiplier+widthModifier) (colour |> next step) (angle+branchAngle)
                branch drawings nextX nextY (length*lengthMultiplier*stageLengthMultiplier) (width*stageWidthMultiplier+widthModifier) (colour |> next step) (angle-branchAngle)
                )

    interface IFractal with

        member this.Title = "Leaf"
        member this.Parameters = parameters

        member this.Calculate drawings =
            let centre = Helpers.ImageCentre drawings
            branch drawings (centre - startWidth/2.0) 150.0 startLength startWidth startColour 0.5


