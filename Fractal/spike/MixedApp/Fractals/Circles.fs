﻿namespace Fractals

open FractalFunctions

type CirclesParameters(radius: float) =

    [<Literal>]
    let DefaultRadius = 200

    member this.Radius = radius

    interface IParameters with

        member this.Name = "Circles"

// Taken from https://github.com/relentless/FractalFun
type Circles(parameters: CirclesParameters) = 

    let next colour =
        let red, green, blue = colour
        (red, green+30, blue)

    let rand seed =
        let rnd = System.Random(seed)
        rnd.Next(0, 255)

    let randCol seed =
        let r = rand seed
        let g = rand r
        let b = rand g
        (r, g, b)

    let rec sphere (drawings : IFractalDrawing) x y radius seed iteration =

        if iteration < 5 then

            drawings.Circle x y (int radius) <| randCol seed

            let nextDist = radius/2.0

            sphere drawings (x-nextDist) (y-nextDist) nextDist (seed*2) (iteration+1)
            sphere drawings (x+nextDist) (y-nextDist) nextDist (seed/2) (iteration+1)
            sphere drawings (x+nextDist) (y+nextDist) nextDist (seed/3) (iteration+1)
            sphere drawings (x-nextDist) (y+nextDist) nextDist (seed*3) (iteration+1)

    interface IFractal with

        member this.Title = "Circles"
        member this.Parameters = parameters :> IParameters

        member this.Calculate drawings =
            Helpers.measureTime sphere 
                drawings
                (float drawings.Width/2.0) 
                (float drawings.Height/2.0)
                parameters.Radius
                System.DateTime.Now.Millisecond
                0