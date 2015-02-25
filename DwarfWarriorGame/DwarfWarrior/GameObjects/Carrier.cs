﻿namespace DwarfWarrior.GameObjects
{
    using System.Collections.Generic;

    using DwarfWarrior.Interfaces;

    public class Carrier : ShootingObject, IRenderable, ICollidable, IShootable
    {
        private const int InitHealth = 3;
        private const int InitDamage = 10;

        public Carrier(Coordinate topLeftPosition, Coordinate speed, char[,] body)
            : base(topLeftPosition, Carrier.InitHealth, Carrier.InitDamage, speed, body)
        {
        }

        public override bool CanCollideWith(ICollidable other)
        {
            return other.Type == ObjectType.Player || other.Type == ObjectType.Shell;
        }

        public override bool CanShootAt(GameObject other)
        {
            Coordinate shootingPoint = this.GetShootingPoint();
            int targetRow = other.TopLeftPosition.Row;

            for (int row = 0; row < other.BodyHeight; row++)
            {
                if (shootingPoint.Row == targetRow)
                {
                    return true;
                }

                targetRow++;
            }

            return false;
        }

        public override Coordinate GetShootingPoint()
        {
            int shootingPointRow = this.TopLeftPosition.Row + 1;
            int shootingPointCol = this.TopLeftPosition.Col - 1;

            return new Coordinate(shootingPointRow, shootingPointCol);
        }
    }
}