﻿using Terraria.ModLoader;
using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework;
using VirtualDream.Utils;
using System.Collections.Generic;
using Terraria.DataStructures;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;
using System;
using ReLogic.Graphics;

namespace VirtualDream.Contents.StarBound.Weapons.BossDrop.SolusKatana
{
    public class SolusKatana : GlowItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("日炎刀");
            Tooltip.SetDefault("日光注入剑中，由阿斯拉诺克斯制造\n由阿斯拉诺克斯造的是初版，后来她开源了......我的意思是，她公布了制作方法，方法很简单:搜集好材料然后怼到秘银砧上面(\n此物品来自[c/cccccc:STARB][c/cccc00:O][c/cccccc:UND]");

        }
        public virtual int CountOfShoot => 3;
        //public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        //{
        //    if (Mod.HasAsset((Texture + "_Glow").Replace("VirtualDream/", "")))
        //        spriteBatch.Draw(IllusionBoundMod.GetTexture(Texture + "_Glow", false), item.Center - Main.screenPosition, null, Color.White, rotation, IllusionBoundMod.GetTexture(Texture + "_Glow", false).Size() * .5f, scale, 0, 0);
        //}

        //public override void UseStyle(Player player)
        //{
        //    if (item.noUseGraphic || !item.melee || item.damage == 0 || item.useStyle != 1) 
        //    {
        //        return;
        //    }
        //    ShaderSwooshEffectPlayer ssep = player.GetModPlayer<ShaderSwooshEffectPlayer>();
        //    if (player.itemAnimation == player.itemAnimationMax - 1) 
        //    {
        //        ssep.playerOldPos = new Vector2[player.itemAnimationMax - 1];
        //    }
        //    ssep.playerOldPos[player.itemAnimationMax - player.itemAnimation - 1] = player.Center;
        //    if (player.itemAnimation == 1) 
        //    {
        //        ssep.NewSwoosh(1 / 12f, item, ShaderSwooshEffectPlayer.ShaderSwooshStyle.LightBlade);
        //    }
        //}
        public override void SetDefaults()
        {
            item.damage = 85;
            item.DamageType = DamageClass.Melee;
            item.width = 66;
            item.rare = MyRareID.Tier1;
            item.width = 76;
            item.useTime = 16;
            item.useAnimation = 16;
            item.knockBack = 8;
            item.useStyle = 1;
            item.autoReuse = true;
            item.shoot = ModContent.ProjectileType<SolusKatanaProj>();
            item.shootSpeed = 1f;
            item.noUseGraphic = true;
            item.noMelee = true;
        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            Dust.NewDust(hitbox.TopLeft(), hitbox.Width, hitbox.Height, MyDustId.Fire, 0, 0, 100, Color.White, 1.0f);
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            //for (int i = 0; i < CountOfShoot; i++)
            //{
            //    float factor = i / (CountOfShoot - 1f);
            //    Vector2 finalVec = Vector2.Normalize(velocity).RotatedBy(factor.Lerp(-MathHelper.Pi / 6, MathHelper.Pi / 6)) * 72f;
            //    Projectile.NewProjectile(source, position, finalVec, ModContent.ProjectileType<SolusEnergyShard>(), damage, knockback, player.whoAmI);
            //}
            //return false;
            return true;
        }
        public Item item => Item;

        public override bool CanUseItem(Player player)
        {
            //if (player.altFunctionUse == 2)
            //{
            //    //item.shoot = ModContent.ProjectileType<SolusEnergyShard>();
            //    item.shootSpeed = 10f;
            //    item.mana = 30;
            //    item.useTime = 48;
            //    item.useAnimation = 48;
            //}
            //else
            //{
            //    item.useTime = 16;
            //    item.mana = 0;
            //    item.shoot = 0;
            //    item.useAnimation = 16;
            //}
            return base.CanUseItem(player);
        }
        //public override bool AltFunctionUse(Player player)
        //{
        //    return true;
        //}
        public override bool AltFunctionUse(Player player) => true;
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {

            target.AddBuff(BuffID.OnFire, 150);
            target.AddBuff(BuffID.Daybreak, 150);
        }
        public override void AddRecipes()
        {
            Recipe recipe1 = CreateRecipe();
            //recipe1.AddIngredient(ModContent.ItemType<Items.Weapons.OrdinaryAcrossKatana>());
            recipe1.AddIngredient(ItemID.SolarTablet);
            recipe1.AddIngredient(ItemID.LihzahrdBrick, 50);
            recipe1.AddIngredient(ItemID.LunarTabletFragment, 32);
            recipe1.AddIngredient(ItemID.Topaz, 15);
            recipe1.AddIngredient(ItemID.Amber, 5);
            recipe1.AddIngredient(ItemID.SunStone);
            recipe1.AddTile(TileID.MythrilAnvil);
            recipe1.SetResult(this);
            recipe1.AddRecipe();
        }
    }
    public class SolusKatanaEX : SolusKatana
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("日光注入剑中，由阿斯拉诺克斯制造\n 它在接受了远古精华的纯化后，拥有了更为强大的纯粹的力量。\n此物品来自[c/cccccc:STARB][c/cccc00:O][c/cccccc:UND]");
            DisplayName.SetDefault("日炎刀EX");
        }
        //public override void UseStyle(Player player)
        //{
        //    if (item.noUseGraphic || !item.melee || item.damage == 0 || item.useStyle != 1)
        //    {
        //        return;
        //    }
        //    ShaderSwooshEffectPlayer ssep = player.GetModPlayer<ShaderSwooshEffectPlayer>();
        //    if (player.itemAnimation == player.itemAnimationMax - 1)
        //    {
        //        ssep.playerOldPos = new Vector2[player.itemAnimationMax - 1];
        //    }
        //    ssep.playerOldPos[player.itemAnimationMax - player.itemAnimation - 1] = player.Center;
        //    if (player.itemAnimation == 1)
        //    {
        //        ssep.NewSwoosh(1 / 12f, item, ShaderSwooshEffectPlayer.ShaderSwooshStyle.LightBlade);
        //    }
        //}
        public override int CountOfShoot => 5;
        public override void SetDefaults()
        {
            base.SetDefaults();
            item.damage = 150;
            item.rare = MyRareID.Tier2;
            item.height = 78;
            item.width = 68;
            item.useTime = 13;
            item.useAnimation = 13;
            item.knockBack = 8;
        }
        //public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        //{
        //    Vector2 vec = Main.MouseWorld - player.Center;
        //    vec = Vector2.Normalize(vec);
        //    for (float i = -MathHelper.Pi / 12; i <= MathHelper.Pi / 12; i += MathHelper.Pi / 24)
        //    {
        //        Vector2 finalVec = (vec.ToRotation() + i).ToRotationVector2() * 72f;
        //        Projectile.NewProjectile(source, position, finalVec, ModContent.ProjectileType<Projectiles.SolarEnergySword.SolarEnergySword>(), damage, knockback, player.whoAmI);
        //    }
        //    return false;
        //}
        //Action<(int, int)> myfunc;
        public override bool CanUseItem(Player player)
        {
            //if (player.altFunctionUse == 2)
            //{
            //    item.shoot = ModContent.ProjectileType<SolusEnergyShard>();
            //    item.shootSpeed = 10f;
            //    item.mana = 40;
            //    item.useTime = 39;
            //    item.useAnimation = 39;
            //}
            //else
            //{
            //    item.useTime = 13;
            //    item.mana = 0;
            //    item.shoot = 0;
            //    item.useAnimation = 13;
            //}
            return true;
        }
        public override void AddRecipes()
        {
        }
    }
    public class SolusKatanaNEO : SolusKatana
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("二次强化的日炎刀，是由阿斯拉诺克斯制造的吗？\n此物品魔改自[c/cccccc:STARB][c/cccc00:O][c/cccccc:UND]");
            DisplayName.SetDefault("日炎刀NEO");
        }
        public override int CountOfShoot => 7;

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.damage = 500;
            item.width = 70;
            item.height = 80;
            item.rare = MyRareID.Tier3;
            item.useTime = 10;
            item.useAnimation = 10;
        }
        int time;
        public override void UseStyle(Player player, Rectangle rectangle)
        {
            //if (item.noUseGraphic || !item.melee || item.damage == 0 || item.useStyle != 1)
            //{
            //    return;
            //}
            //ShaderSwooshEffectPlayer ssep = player.GetModPlayer<ShaderSwooshEffectPlayer>();
            //if (player.itemAnimation == player.itemAnimationMax - 1)
            //{
            //    ssep.playerOldPos = new Vector2[player.itemAnimationMax - 1];
            //}
            //ssep.playerOldPos[player.itemAnimationMax - player.itemAnimation - 1] = player.Center;
            //if (player.itemAnimation == 1)
            //{
            //    ssep.NewSwoosh(1 / 12f, item, ShaderSwooshEffectPlayer.ShaderSwooshStyle.LightBlade);
            //}
            //if (player.altFunctionUse != 2)
            //{
            //    time++;
            //    if (time == 20)
            //    {
            //        Vector2 vec = Main.MouseWorld - player.Center;
            //        vec = Vector2.Normalize(vec);
            //        for (float i = -MathHelper.Pi / 12; i <= MathHelper.Pi / 12; i += MathHelper.Pi / 12)
            //        {
            //            Vector2 finalVec = (vec.ToRotation() + i).ToRotationVector2() * 72f;
            //            Projectile.NewProjectile(player.GetSource_ItemUse(item), player.position, finalVec, ModContent.ProjectileType<SolusEnergyShard>(), player.GetWeaponDamage(item), 8, player.whoAmI);
            //        }
            //        time = 0;
            //    }
            //}
        }
        public override bool CanUseItem(Player player)
        {
            //if (player.altFunctionUse == 2)
            //{
            //    item.shoot = ModContent.ProjectileType<SolusEnergyShard>();
            //    item.shootSpeed = 10f;
            //    item.mana = 50;
            //    item.useTime = 30;
            //    item.useAnimation = 30;
            //}
            //else
            //{
            //    item.useTime = 10;
            //    item.mana = 0;
            //    item.shoot = 0;
            //    item.useAnimation = 10;
            //}
            return true;
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            target.AddBuff(BuffID.OnFire, 450);
            target.AddBuff(BuffID.Daybreak, 450);
        }
        public override void HoldItem(Player player)
        {
            float theta = 3.1415926f / 180 * (float)IllusionBoundMod.ModTime2;
            for (float n = 0; n < 4; n++)
            {
                Dust.NewDustPerfect(player.Center + (n * MathHelper.PiOver2 + theta).ToRotationVector2() * (float)(Math.Tan(0.5f * 8 * theta) + 8) * 25, MyDustId.Fire, new Vector2(0f, 0f), 0, Color.White, 2f).noGravity = true;
            }
        }
    }
    public class SolusKatanaProj : VertexHammerProj
    {
        public override string HammerName => base.HammerName;
        public override float MaxTime => Charging && projectile.ai[1] == 0 && controlState == 1 ? (UpgradeValue(MathHelper.Clamp(16 - counter / 5, 10, 16), MathHelper.Clamp(13 - counter / 4, 8, 13), MathHelper.Clamp(10 - counter / 3, 5, 10))) : UpgradeValue(30, 25, 20);
        public override float factor => base.factor;
        public override Vector2 CollidingSize => base.CollidingSize * 2;
        //public override Vector2 projCenter => base.projCenter + new Vector2(Player.direction * 16, -16);
        public override Vector2 CollidingCenter => new Vector2(projTex.Size().X / 3 - 16, 16);
        public override Vector2 DrawOrigin => base.DrawOrigin + new Vector2(-16, 12);// + new Vector2(-12, 12)
        public override Color color => base.color;
        public override float MaxTimeLeft => (controlState == 2 ? UpgradeValue(7, 6, 5) : swooshTimeLeft);

        public override Color VertexColor(float time) => Color.Lerp(Color.White, Color.Orange, time);
        public override bool UseRight => true;
        public override (int X, int Y) FrameMax => (3, 1);
        public override void VertexInfomation(ref bool additive, ref int indexOfGreyTex, ref float endAngle, ref bool useHeatMap, ref (float M, float Intensity, float Range) useBloom, ref (float M, float Range, Vector2 director) useDistort)
        {
            additive = true;
            indexOfGreyTex = UpgradeValue(5, 5, 7);
            useHeatMap = true;
            useBloom = (0f, 0.2f, 3f);//(controlState == 1 && counter > 0 ? 1f : factor) * .25f//0.7f
            useDistort = (0f, 5f, (controlState == 1 ? CurrentSwoosh.rotation : Rotation).ToRotationVector2() * -0.006f);//
        }
        public override Texture2D HeatMap
        {
            get
            {
                //if (heatMap == null)
                //{
                //    Main.RunOnMainThread
                //    (
                //        () =>
                //        {
                //            var colors = new Color[300];
                //            for (int i = 0; i < 300; i++)
                //            {
                //                var f = i / 299f;//分割成25次惹，f从1/25f到1//1 - 
                //                f = f * f;// *f
                //                          //float h = (hsl.X + instance.hueOffsetValue + instance.hueOffsetRange * (2 * f - 1)) % 1;
                //                          //float s = MathHelper.Clamp(hsl.Y * instance.saturationScalar, 0, 1);
                //                          //float l = MathHelper.Clamp(f > 0.5f ? hsl.Z * (2 - f * 2) + (f * 2 - 1) * Math.Max(hsl.Z, 0.5f + instance.luminosityRange) : f * 2 * hsl.Z + (1 - f * 2) * Math.Min(hsl.Z, 0.5f - instance.luminosityRange), 0, 1);
                //                          //colors[i] = Main.hslToRgb(1 / 12f, 1, f * .5f + .5f);
                //                colors[i] = f.GetLerpValue(Color.Red, Color.Orange, Color.White);
                //            }
                //            heatMap = new Texture2D(Main.instance.GraphicsDevice, 300, 1);
                //            heatMap.SetData(colors);
                //        }
                //    );
                //}
                //return IllusionBoundMod.HeatMap[19];
                return IllusionBoundMod.HeatMap[24];
            }
        }
        public override float Rotation
        {
            get
            {
                if (controlState == 2) return base.Rotation;// && !(Charged && projectile.ai[1] > MaxTimeLeft * factor - 1)
                if (CurrentSwoosh == null) return 0;
                var theta = (1.8375f * factor - 1.125f) * MathHelper.Pi + MathHelper.Pi;// 
                if (CurrentSwoosh.direction == 1) theta = MathHelper.TwoPi - theta;

                //var maxCount = (int)MathHelper.Clamp((counter - (int)Projectile.ai[1]) / UpgradeValue(3, 2, 1), UpgradeValue(2, 3, 4), UpgradeValue(5, 7, 9));
                //if (Projectile.ai[1] == maxCount - 1) return CurrentSwoosh.rotation;
                var vec = -2 * (theta.ToRotationVector2() * new Vector2(CurrentSwoosh.xScaler, 1)).RotatedBy(CurrentSwoosh.rotation) * CurrentSwoosh.Scaler(this);
                //Main.NewText(CurrentSwoosh.Scaler(this));
                /*if (timeCount != 0)*/
                CurrentSwoosh.currentPosition = vec;
                if (projectile.ai[1] > 0 && projectile.ai[1] == projectile.frame) return (Player.direction == 1 ? 7 : 1) * MathHelper.Pi / 8;

                return vec.ToRotation();
                //return 1;
            }
        }
        public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
        {

            //if ((int)projectile.ai[1] == 0 && controlState != 1)
            //{
            //    return false;
            //}
            //float point = 0f;
            //return targetHitbox.Intersects(Terraria.Utils.CenteredRectangle((CollidingCenter - DrawOrigin).RotatedBy(Rotation) + projCenter, CollidingSize)) || Collision.CheckAABBvLineCollision(targetHitbox.TopLeft(), targetHitbox.Size(), projCenter, (CollidingCenter - DrawOrigin).RotatedBy(Rotation) + projCenter, 8, ref point);
            //float point = 0f;
            //Vector2 vec = Pos - player.Center;
            //vec.Normalize();
            //bool flag2 = Collision.CheckAABBvLineCollision(targetHitbox.TopLeft(), targetHitbox.Size(), player.Center - vec * (30 - Distance - NegativeDistance), player.Center + vec * (66 + Distance + NegativeDistance), 18, ref point);
            //return flag2;
            if (controlState == 1)// || (Charged && projectile.ai[1] > MaxTimeLeft * factor - 1)
            {
                if (UpgradeValue(false, false, true))
                {
                    foreach (var swoosh in leftSwooshes)
                    {
                        if (swoosh != null && swoosh.Active)
                        {
                            for (int n = 0; n < 6; n++)
                            {
                                float _point = 0f;
                                var f = n / 5f;
                                float theta2 = (1.8375f * f.Lerp(1 - swoosh.timeLeft / swooshTimeLeft, (swoosh.GetHashCode() == CurrentSwoosh.GetHashCode() ? factor : 1)) - 1.125f) * MathHelper.Pi + MathHelper.Pi;
                                if (swoosh.direction == 1) theta2 = MathHelper.TwoPi - theta2;
                                Vector2 newVec = -2 * (theta2.ToRotationVector2() * new Vector2(swoosh.xScaler, 1)).RotatedBy(swoosh.rotation) * swoosh.Scaler(this) * (1 + (1 - swoosh.timeLeft / swooshTimeLeft) * .25f);
                                if (Collision.CheckAABBvLineCollision(targetHitbox.TopLeft(), targetHitbox.Size(), swoosh.center, newVec + swoosh.center, 8, ref _point)) return true;
                            }
                        }
                    }
                }
                float point = 0f;
                return Collision.CheckAABBvLineCollision(targetHitbox.TopLeft(), targetHitbox.Size(), projCenter, CurrentSwoosh.currentPosition + projCenter, 8, ref point);
            }
            else return base.Colliding(projHitbox, targetHitbox);
        }
        public override void OnCharging(bool left, bool right)
        {
            //Main.NewText(WhenVertexDraw);
            if (left && !right)
            {

                if (timeCount % MaxTime == 0)
                {
                    projectile.damage = Player.GetWeaponDamage(Player.HeldItem);
                    currentSwoosh = NewSwoosh();
                    SoundEngine.PlaySound(SoundID.Item71);
                    counter++;
                    timeCount = 0;
                }


                try
                {
                    for (int n = 0; n < leftSwooshes.Length; n++)
                    {
                        if (leftSwooshes == null) leftSwooshes = new LeftSwoosh[10];
                        if (leftSwooshes[n] != null && leftSwooshes[n].timeLeft > 0)
                            leftSwooshes[n].timeLeft--;
                    }
                }
                catch
                {
                    Main.NewText(timeCount % MaxTime == 0);
                }
                //CurrentSwoosh.startAngle = Rotation;
                CurrentSwoosh.timeLeft = (byte)swooshTimeLeft;
                //leftSwooshes[0] = new LeftSwoosh(); 
                CurrentSwoosh.center = Player.Center;

                //Main.NewText(Player.controlUseTile);
            }
        }
        LeftSwoosh CurrentSwoosh
        {
            get
            {
                if (leftSwooshes[currentSwoosh] == null) currentSwoosh = NewSwoosh();
                return leftSwooshes[currentSwoosh];
            }
        }
        int NewSwoosh(int? maxCount = null)
        {
            var index = -1;
            for (int n = 0; n < maxSwoosh; n++)
            {
                if (leftSwooshes[n] == null)
                {
                    //Main.NewText("!!" + currentSwoosh);
                    for (int i = 0; i < maxSwoosh; i++)
                    {
                        leftSwooshes[i] = new LeftSwoosh();
                    }
                }
                var swoosh = leftSwooshes[n];
                if (!leftSwooshes[n].Active)
                {
                    swoosh.timeLeft = (byte)swooshTimeLeft;
                    swoosh.xScaler = Main.rand.NextFloat(1, 3);
                    var vec = Main.MouseWorld - Player.Center;
                    vec.Y *= Player.gravDir;

                    if (maxCount != null && (int)projectile.ai[1] == maxCount - 1)
                    {
                        swoosh.rotation = Player.direction == 1 ? 0 : MathHelper.Pi;
                        swoosh.direction = (byte)(Player.direction == 1 ? 1 : 0);
                    }
                    else
                    {
                        swoosh.rotation = vec.ToRotation() + Main.rand.NextFloat(-1, 1) * MathHelper.Pi / UpgradeValue(6, 4, 3);//+ (Projectile.ai[1] == maxCount ? 0 : Main.rand.NextFloat(-1, 1) * MathHelper.Pi / UpgradeValue(6, 4, 3))
                        swoosh.direction = (byte)(counter % 2);
                    }
                    swoosh.center = projCenter;
                    index = n;
                    //leftSwooshes[n] = swoosh;
                    //Main.NewText(n);
                    break;
                }
            }
            //Main.NewText("!!!!");

            return index == -1 ? currentSwoosh : index;
        }
        //public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
        //{
        //    if(controlState == 2)
        //    return base.Colliding(projHitbox, targetHitbox);
        //    //return Collision.CheckAABBvLineCollision(targetHitbox.TopLeft(), targetHitbox.Size(), projCenter, (CollidingCenter - DrawOrigin).RotatedBy(Rotation) + projCenter, 8, ref point);
        //}
        //public override bool Charged => base.Charged;
        public override void OnRelease(bool charged, bool left)
        {
            //if (timeCount % MaxTime == 0)
            //{
            //    currentSwoosh = NewSwoosh();
            //    SoundEngine.PlaySound(SoundID.Item71);
            //    counter++;
            //    timeCount = 0;
            //}
            //Main.NewText(controlState);
            //Main.NewText(left,Color.Red);
            //Main.NewText(Player.velocity.Y == 0);
            if (Player.velocity.Y == 0) Player.velocity.X *= 0.975f;
            if (left)//|| (!left && charged && projectile.ai[1] > MaxTimeLeft * factor - 1)
            {
                if (projectile.frame == 0) 
                {
                    projectile.frame = (int)MathHelper.Clamp((counter - (int)Projectile.ai[1]) / UpgradeValue(3, 2, 1), UpgradeValue(2, 3, 4), UpgradeValue(5, 7, 9));
                    //Main.NewText(counter);
                }
                //var maxCount = (int)MathHelper.Clamp((counter - (int)Projectile.ai[1]) / UpgradeValue(3, 2, 1), UpgradeValue(2, 3, 4), UpgradeValue(5, 7, 9));
                //Main.NewText(maxCount);
                if (Projectile.ai[1] < projectile.frame)
                {
                    if (timeCount % UpgradeValue(6, 5, 4) == 0 && Projectile.ai[1] < projectile.frame)
                    {
                        if (Projectile.ai[1] == 0)
                        {
                            Player.velocity = (Main.MouseWorld - Player.Center).SafeNormalize(default) * 24 * new Vector2(1, UpgradeValue(0, 0.5f, 1));
                            //Player.velocity = Player.velocity.SafeNormalize(default) * 24;
                        }

                        currentSwoosh = NewSwoosh(projectile.frame);
                        SoundEngine.PlaySound(SoundID.Item71);
                        counter++;
                        timeCount = 0;
                        Projectile.ai[1]++;
                        Player.immune = true;
                        Player.immuneTime = 4;

                    }
                    timeCount++;
                }
                Player.immune = true;
                Player.immuneTime = 2;

                //Player.GetDamage(DamageClass.Generic) += 0.2f;
                //Main.NewText(timeCount);
                try
                {
                    for (int n = 0; n < leftSwooshes.Length; n++)
                    {
                        if (leftSwooshes == null) leftSwooshes = new LeftSwoosh[10];
                        if (leftSwooshes[n] != null && leftSwooshes[n].timeLeft > 0)
                            leftSwooshes[n].timeLeft--;
                    }
                }
                catch
                {
                    Main.NewText(timeCount % MaxTime == 0);
                }
                if (!CurrentSwoosh.Active && Projectile.ai[1] >= projectile.frame) { projectile.Kill();}
                return;
            }
            //else 
            //{
            //    if (charged) 
            //    {

            //    }
            //}
            base.OnRelease(charged, left);
            //CurrentSwoosh.startAngle = Rotation;
            //CurrentSwoosh.timeLeft = (byte)swooshTimeLeft;
            ////leftSwooshes[0] = new LeftSwoosh(); 
            //CurrentSwoosh.center = Player.Center;
            ////base.OnRelease(charged, left);
            //Projectile.ai[1]++;
            //if (Projectile.ai[1] > swooshTimeLeft)
            //{
            //    projectile.Kill();
            //}
        }
        public class LeftSwoosh
        {
            public Vector2 currentPosition;//float startAngle;
            public float rotation;
            public byte timeLeft;
            public float xScaler;
            public Vector2 center;
            public byte direction;
            public bool Active => timeLeft > 0;
            public float Scaler(SolusKatanaProj instance) => (instance.CollidingCenter - instance.DrawOrigin).Length() * instance.Player.GetAdjustedItemScale(instance.Player.HeldItem) / (float)Math.Sqrt(xScaler) * (Main.GameViewMatrix != null ? Main.GameViewMatrix.TransformationMatrix : Matrix.Identity).M11 * .5f;// * 3f
            //public int whoAmI;
        }
        int currentSwoosh;
        int counter;
        //int Projectile.ai[1];
        //int specialAttackCount;
        const int maxSwoosh = 10;
        LeftSwoosh[] leftSwooshes = new LeftSwoosh[maxSwoosh];
        public override CustomVertexInfo[] CreateVertexs(Vector2 drawCen, float scaler, float startAngle, float endAngle, float alphaLight, ref int[] whenSkip)
        {
            if (controlState == 2 && !(Charged && projectile.ai[1] > MaxTimeLeft * factor - 1)) return base.CreateVertexs(drawCen, scaler, startAngle, endAngle, alphaLight, ref whenSkip);
            List<CustomVertexInfo> bars = new List<CustomVertexInfo>();
            List<int> indexer = new List<int>();
            foreach (var swoosh in leftSwooshes)
            {
                if (swoosh != null && swoosh.Active)
                {
                    bool inv = projectile.ai[1] > 0 && projectile.ai[1] == projectile.frame && swoosh.GetHashCode() == CurrentSwoosh.GetHashCode();
                    for (int i = 0; i < 45; i++)
                    {
                        var f = i / 44f;
                        var lerp = f.Lerp(inv ? swoosh.timeLeft / swooshTimeLeft : 1 - swoosh.timeLeft / swooshTimeLeft, (swoosh.GetHashCode() == CurrentSwoosh.GetHashCode() ? factor : 1));
                        float theta2 = (1.8375f * lerp - 1.125f) * MathHelper.Pi + MathHelper.Pi;////(swoosh.GetHashCode() == CurrentSwoosh.GetHashCode() ? (factor) : 1) * 
                        //
                        if (swoosh.direction == 1) theta2 = MathHelper.TwoPi - theta2;
                        Vector2 newVec = -2 * (theta2.ToRotationVector2() * new Vector2(swoosh.xScaler, 1)).RotatedBy(swoosh.rotation) * swoosh.Scaler(this) * (1 + (1 - swoosh.timeLeft / swooshTimeLeft) * .25f);
                        //var _f = 6 * f / (3 * f + 1);
                        //_f = MathHelper.Clamp(_f, 0, 1);
                        var realColor = VertexColor(f);
                        realColor.A = (byte)((1 - f).HillFactor2(1) * swoosh.timeLeft / swooshTimeLeft * 255);//((float)Math.Pow(swoosh.timeLeft / swooshTimeLeft,4)).Lerp(, f)
                        //
                        bars.Add(new CustomVertexInfo(swoosh.center + newVec, realColor, new Vector3(1 - f, 1, alphaLight)));
                        realColor.A = 0;
                        bars.Add(new CustomVertexInfo(swoosh.center, realColor, new Vector3(0, 0, alphaLight)));
                        //if (i == 44 && projectile.ai[1] > 0 && projectile.ai[1] == projectile.frame && swoosh.GetHashCode() == CurrentSwoosh.GetHashCode())
                        //{
                        //    //Main.spriteBatch.DrawLine(swoosh.center, swoosh.center + newVec, Color.Red, drawOffset: -Main.screenPosition);
                        //    Main.NewText((1 - swoosh.timeLeft / swooshTimeLeft, swoosh.timeLeft));
                        //}
                    }
                    indexer.Add(bars.Count - 2);
                    //Main.spriteBatch.DrawString(FontAssets.MouseText.Value, swoosh.timeLeft.ToString(), swoosh.currentPosition + swoosh.center - Main.screenPosition, Color.AliceBlue);
                }

            }
            whenSkip = indexer.ToArray();
            return bars.ToArray();//base.CreateVertexs(drawCen, scaler, startAngle, endAngle, alphaLight).Union(bars)
        }
        public override bool WhenVertexDraw => controlState == 1 || base.WhenVertexDraw;
        public override void Kill(int timeLeft)
        {
            int max = (int)(30 * factor);
            var vec = (CollidingCenter - DrawOrigin).RotatedBy(Rotation) + projCenter;
            if (Charged && controlState == 2)
            {
                for (int n = 0; n < max; n++)
                {
                    Dust.NewDustPerfect(vec, MyDustId.OrangeFx, (MathHelper.TwoPi / max * n).ToRotationVector2() * Main.rand.NextFloat(2, 8)).noGravity = true;
                }
                var count = UpgradeValue(3, 5, 7);
                for (int i = 0; i < count; i++)
                {
                    float factor = i / (count - 1f);
                    Vector2 finalVec = Vector2.Normalize(Main.MouseWorld - projCenter).RotatedBy(factor.Lerp(-MathHelper.Pi / 6, MathHelper.Pi / 6)) * 72f;
                    Projectile.NewProjectile(projectile.GetSource_FromThis(), projCenter, finalVec, ModContent.ProjectileType<SolusEnergyShard>(), Player.GetWeaponDamage(Player.HeldItem), projectile.knockBack, projectile.owner);
                }
                SoundEngine.PlaySound(Terraria.ID.SoundID.Item62);
            }


            //if (factor == 1)
            //{
            //    Projectile.NewProjectile(projectile.GetSource_FromThis(), vec, default, ModContent.ProjectileType<HolyExp>(), player.GetWeaponDamage(player.HeldItem) * 3, projectile.knockBack, projectile.owner);
            //}
            base.Kill(timeLeft);
        }
        public override bool RedrawSelf => true;//controlState == 1
        public override bool PreDraw(ref Color lightColor)
        {
            //var maxCount = (int)MathHelper.Clamp((counter - (int)Projectile.ai[1]) / UpgradeValue(3, 2, 1), UpgradeValue(2, 3, 4), UpgradeValue(5, 7, 9));
            if (controlState == 1)// || (Charged && projectile.ai[1] > MaxTimeLeft * factor - 1))// && Projectile.ai[1] < maxCount
            {
                var scaler = CurrentSwoosh.currentPosition.Length() / (projTex.Size() / new Vector2(FrameMax.X, FrameMax.Y)).Length();
                var rotation = Rotation + MathHelper.PiOver4;
                var flip = CurrentSwoosh.direction == 1 ? SpriteEffects.FlipHorizontally : 0;
                var origin = DrawOrigin;
                switch (flip)
                {
                    case SpriteEffects.FlipHorizontally:
                        origin.X = projTex.Size().X / FrameMax.X - origin.X;
                        rotation += MathHelper.PiOver2;

                        break;
                    case SpriteEffects.FlipVertically:
                        origin.Y = projTex.Size().Y / FrameMax.Y - origin.Y;
                        break;
                }
                //Main.NewText(Projectile.ai[1] == projectile.frame);
                Main.spriteBatch.Draw(projTex, projCenter - Main.screenPosition, frame, color, rotation, origin, scaler, flip, 0);

                Main.spriteBatch.Draw(GlowEffect, projCenter - Main.screenPosition, frame, Color.White, rotation, origin, scaler, flip, 0);

                //Main.spriteBatch.DrawLine(projCenter, projCenter + CurrentSwoosh.currentPosition, Color.Cyan, drawOffset: -Main.screenPosition);

            }
            else
            {
                Main.spriteBatch.DrawHammer(this, GlowEffect, Color.White, frame);
            }
            if (controlState == 2 && UpgradeValue(false, true, true))
            {
                Vector2 baseVec = (Rotation - MathHelper.PiOver2).ToRotationVector2();
                Vector2 start = new Vector2(23 * baseVec.X - 20 * baseVec.Y, 23 * baseVec.Y + 20 * baseVec.X);
                Vector2 end = new Vector2(70 * baseVec.X - 77 * baseVec.Y, 70 * baseVec.Y + 77 * baseVec.X);
                Main.spriteBatch.DrawQuadraticLaser_PassColorBar(start + projCenter, Vector2.Normalize(end - start), 15, (start - end).Length() * factor, 30, texcoord: (0, 0, factor, 1));
            }
            return base.PreDraw(ref lightColor);
        }
        public float swooshTimeLeft => 30;
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            base.OnHitNPC(target, damage, knockback, crit);
            target.AddBuff(BuffID.OnFire, controlState == 2 ? 750 : 450);
            target.AddBuff(BuffID.Daybreak, controlState == 2 ? 750 : 450);
            target.immune[projectile.owner] = (controlState == 2 || projectile.ai[1] > 0) ? UpgradeValue(6, 5, 4) : (int)MathHelper.Clamp(MaxTime - 3, 3, 10);
            //var strength = 0f;
            //if (controlState == 1 && projectile.ai[1] < 1)
            //{
            //    strength = (UpgradeValue(16, 13, 10) - MaxTime) / UpgradeValue(6f, 5f, 5f) * 4f;

            //}
            //if (controlState == 2)
            //{
            //    strength = 8f;
            //}
            //VirtualDreamPlayer.screenShakeStrength += strength;
            //Dust.NewDustPerfect(target.Center, MyDustId.Fire, (Rotation + MathHelper.PiOver2 * (counter % 2 == 0 ? 1 : -1)).ToRotationVector2());
        }
        public override Rectangle? frame => projTex.Frame(3, 1, UpgradeValue(0, 1, 2));
        public T UpgradeValue<T>(T normal, T extra, T ultra, T defaultValue = default)
        {
            var type = Player.HeldItem.type;
            if (type == ModContent.ItemType<SolusKatana>())
            {
                return normal;
            }

            if (type == ModContent.ItemType<SolusKatanaEX>())
            {
                return extra;
            }

            if (type == ModContent.ItemType<SolusKatanaNEO>())
            {
                return ultra;
            }

            return defaultValue;
        }
    }
    public class SolusEnergyShard : ModProjectile
    {
        Projectile projectile => Projectile;
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
            DisplayName.SetDefault("日炎能量飞刀");
        }

        public override void SetDefaults()
        {
            projectile.width = 16;
            projectile.height = 16;
            projectile.friendly = true;
            projectile.DamageType = DamageClass.Melee;
            projectile.ignoreWater = true;
            projectile.timeLeft = 180;
            projectile.tileCollide = true;
            projectile.penetrate = -1;
            projectile.light = 0.5f;
            projectile.aiStyle = -1;
        }
        public override bool PreDraw(ref Color lightColor)
        {
            if (projectile.ai[0] != 0) return false;
            SpriteBatch spriteBatch = Main.spriteBatch;
            if (projectile.timeLeft > 30)
            {
                Texture2D projectileTexture = TextureAssets.Projectile[projectile.type].Value;
                var length = projectile.velocity.Length();
                var scaleVec = new Vector2(projectile.scale * 3 + 1f - MathHelper.Clamp(length / 4f, 0, 1), projectile.scale * 2);
                //Main.instance.GraphicsDevice.BlendState = BlendState.Additive;
                for (int k = projectile.oldPos.Length - 1; k > 0; k--)
                {
                    Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + new Vector2(8);
                    var factor = 1 - k / (float)projectile.oldPos.Length;
                    spriteBatch.Draw(projectileTexture, drawPos, null, Color.Orange * factor, projectile.rotation, new Vector2(7.5f, 3.5f), (1 - 0.1f * k) * scaleVec, SpriteEffects.None, 0f);
                }
                if (projectile.ai[1] > 0)
                {
                    var f = (projectile.timeLeft - 30) / 115f;
                    var _f = f.HillFactor2(1);
                    for (int n = 0; n < 4; n++)
                    {
                        spriteBatch.Draw(projectileTexture, projectile.Center - Main.screenPosition + Main.rand.NextVector2Unit() * Main.rand.NextFloat(0, 16 * _f), null, new Color(1f, 1f, 1f, 0) * f, projectile.rotation, new Vector2(7.5f, 3.5f), scaleVec, 0, 0);
                    }
                }
                //Main.NewText((int)projectile.ai[1]);

                var unit = projectile.rotation.ToRotationVector2();
                spriteBatch.Draw(projectileTexture, projectile.Center - Main.screenPosition, null, Color.White, projectile.rotation, new Vector2(7.5f, 3.5f), scaleVec, SpriteEffects.None, 0f);
                //Main.instance.GraphicsDevice.BlendState = BlendState.AlphaBlend;

                spriteBatch.DrawQuadraticLaser_PassColorBar(unit * 8 + projectile.Center, -unit, 15, length * 2 + 28, 30);


                //var length = projectile.velocity.Length();
                //var xScaler = MathHelper.Clamp(6 - length / 4, 1, 4);

                //spriteBatch.DrawPath
                //(
                //    (t) =>
                //    {
                //        var _t = t * 4f;
                //        var offsetLeft = projectile.timeLeft - _t % 1 * 20;
                //        var baseVec = (offsetLeft / 60f * MathHelper.Pi).ToRotationVector2() * new Vector2(1, 0.75f);
                //        var vec = new Vector2(baseVec.X - baseVec.Y, baseVec.X + baseVec.Y) * 0.707f;
                //        for (int n = 0; n < (int)_t; n++) vec = new Vector2(-vec.Y, vec.X);
                //        return projectile.Center + (vec / new Vector2(xScaler, 1)).RotatedBy(projectile.rotation) * 128 * offsetLeft / 150f;
                //    },
                //    (t) => t.GetLerpValue(Color.White, Color.Orange, Color.Yellow),
                //    IllusionBoundMod.ShaderSwoosh,
                //    IllusionBoundMod.AniTexes[6],
                //    IllusionBoundMod.AniTexes[10],
                //    default,
                //    80,
                //    widthFunc: (t) => t.HillFactor2(1) * 16 * (projectile.timeLeft - 30) / 150,
                //    skipPoint: new int[] { 40, 80, 120 },
                //    kOfX: 4
                //);
            }
            //else 
            //{

            //}
            return false;
        }
        //public void DrawSwooshExp()
        //{
        //    List<CustomVertexInfo> bars = new List<CustomVertexInfo>();
        //    List<int> indexer = new List<int>();
        //    foreach (var swoosh in swooshes)
        //    {
        //        if (swoosh != null && swoosh.Active)
        //        {
        //            for (int i = 0; i < 45; i++)
        //            {
        //                var f = i / 44f;
        //                var lerp = f.Lerp(1 - swoosh.timeLeft / 30f, 1);
        //                float theta2 = (1.8375f * lerp - 1.125f) * MathHelper.Pi + MathHelper.Pi;
        //                if (swoosh.direction == 1) theta2 = MathHelper.TwoPi - theta2;
        //                var scaler = 50 * Player.GetAdjustedItemScale(Player.HeldItem) / (float)Math.Sqrt(swoosh.xScaler) * (Main.GameViewMatrix != null ? Main.GameViewMatrix.TransformationMatrix : Matrix.Identity).M11 * .5f;
        //                Vector2 newVec = -2 * (theta2.ToRotationVector2() * new Vector2(swoosh.xScaler, 1)).RotatedBy(swoosh.rotation) * scaler * (1 + (1 - swoosh.timeLeft / 30f));
        //                var realColor = Color.Lerp(Color.White, Color.Orange, f);
        //                realColor.A = (byte)((1 - f).HillFactor2(1) * swoosh.timeLeft / 30f * 255);
        //                bars.Add(new CustomVertexInfo(swoosh.center + newVec, realColor, new Vector3(1 - f, 1, 0.6f)));
        //                realColor.A = 0;
        //                bars.Add(new CustomVertexInfo(swoosh.center, realColor, new Vector3(0, 0, 0.6f)));
        //            }
        //            indexer.Add(bars.Count - 2);
        //        }
        //    }
        //    if (bars.Count > 2)
        //    {
        //        var projection = Matrix.CreateOrthographicOffCenter(0, Main.screenWidth, Main.screenHeight, 0, 0, 1);
        //        var model = Matrix.CreateTranslation(new Vector3(-Main.screenPosition.X, -Main.screenPosition.Y, 0));
        //        RasterizerState originalState = Main.graphics.GraphicsDevice.RasterizerState;
        //        var trans = Main.GameViewMatrix != null ? Main.GameViewMatrix.TransformationMatrix : Matrix.Identity;

        //        SamplerState sampler = SamplerState.LinearClamp;
        //        CustomVertexInfo[] triangleList = new CustomVertexInfo[(bars.Count - 2) * 3];//
        //        for (int i = 0; i < bars.Count - 2; i += 2)
        //        {
        //            if (indexer.ToArray().ContainsValue(i)) continue;
        //            var k = i / 2;
        //            if (6 * k < triangleList.Length)
        //            {
        //                triangleList[6 * k] = bars[i];
        //                triangleList[6 * k + 1] = bars[i + 2];
        //                triangleList[6 * k + 2] = bars[i + 1];
        //            }
        //            if (6 * k + 3 < triangleList.Length)
        //            {
        //                triangleList[6 * k + 3] = bars[i + 1];
        //                triangleList[6 * k + 4] = bars[i + 2];
        //                triangleList[6 * k + 5] = bars[i + 3];
        //            }
        //        }
        //        //GraphicsDevice gd = Main.instance.GraphicsDevice;
        //        //RenderTarget2D render = IllusionBoundMod.Instance.render;
        //        SpriteBatch spriteBatch = Main.spriteBatch;
        //        spriteBatch.End();
        //        //gd.SetRenderTarget(render);
        //        //gd.Clear(Color.Transparent);
        //        spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.Additive, sampler, DepthStencilState.Default, RasterizerState.CullNone, null, trans * 2);//Main.DefaultSamplerState//Main.GameViewMatrix.TransformationMatrix
        //        IllusionBoundMod.ShaderSwooshEX.Parameters["uTransform"].SetValue(model * projection);
        //        IllusionBoundMod.ShaderSwooshEX.Parameters["uLighter"].SetValue(0);
        //        IllusionBoundMod.ShaderSwooshEX.Parameters["uTime"].SetValue(0);//-(float)Main.time * 0.06f
        //        IllusionBoundMod.ShaderSwooshEX.Parameters["checkAir"].SetValue(true);
        //        IllusionBoundMod.ShaderSwooshEX.Parameters["airFactor"].SetValue(1);
        //        IllusionBoundMod.ShaderSwooshEX.Parameters["gather"].SetValue(true);
        //        Main.graphics.GraphicsDevice.Textures[0] = IllusionBoundMod.GetTexture("Images/BaseTex_7");
        //        Main.graphics.GraphicsDevice.Textures[1] = IllusionBoundMod.GetTexture("Images/AniTex");
        //        Main.graphics.GraphicsDevice.Textures[2] = TextureAssets.Item[Player.HeldItem.type].Value;
        //        Main.graphics.GraphicsDevice.Textures[3] = IllusionBoundMod.HeatMap[24];

        //        Main.graphics.GraphicsDevice.SamplerStates[0] = sampler;
        //        Main.graphics.GraphicsDevice.SamplerStates[1] = sampler;
        //        Main.graphics.GraphicsDevice.SamplerStates[2] = sampler;
        //        Main.graphics.GraphicsDevice.SamplerStates[2] = sampler;

        //        IllusionBoundMod.ShaderSwooshEX.CurrentTechnique.Passes[2].Apply();
        //        Main.graphics.GraphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleList, triangleList, 0, bars.Count - 2);
        //        Main.graphics.GraphicsDevice.RasterizerState = originalState;
        //        //spriteBatch.End();
        //        //Main.spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
        //        //IllusionBoundMod.Distort.Parameters["offset"].SetValue(new Vector2(Main.screenWidth, Main.screenHeight));
        //        //IllusionBoundMod.Distort.Parameters["tex0"].SetValue(render);

        //        //IllusionBoundMod.Distort.Parameters["position"].SetValue(new Vector2(0, 3));
        //        //IllusionBoundMod.Distort.Parameters["tier2"].SetValue(0.2f);
        //        //for (int n = 0; n < 1; n++)
        //        //{
        //        //    gd.SetRenderTarget(Main.screenTargetSwap);
        //        //    gd.Clear(Color.Transparent);
        //        //    IllusionBoundMod.Distort.CurrentTechnique.Passes[3].Apply();
        //        //    spriteBatch.Draw(Main.screenTarget, Vector2.Zero, Color.White);



        //        //    gd.SetRenderTarget(Main.screenTarget);
        //        //    gd.Clear(Color.Transparent);
        //        //    IllusionBoundMod.Distort.CurrentTechnique.Passes[2].Apply();
        //        //    spriteBatch.Draw(Main.screenTargetSwap, Vector2.Zero, Color.White);
        //        //}

        //        //IllusionBoundMod.Distort.Parameters["position"].SetValue(new Vector2(0, 5));
        //        //IllusionBoundMod.Distort.Parameters["ImageSize"].SetValue(projectile.rotation.ToRotationVector2() * -0.006f);
        //        //for (int n = 0; n < 1; n++)
        //        //{
        //        //    gd.SetRenderTarget(Main.screenTargetSwap);
        //        //    gd.Clear(Color.Transparent);
        //        //    IllusionBoundMod.Distort.CurrentTechnique.Passes[5].Apply();
        //        //    spriteBatch.Draw(Main.screenTarget, Vector2.Zero, Color.White);

        //        //    gd.SetRenderTarget(Main.screenTarget);
        //        //    gd.Clear(Color.Transparent);
        //        //    IllusionBoundMod.Distort.CurrentTechnique.Passes[4].Apply();
        //        //    spriteBatch.Draw(Main.screenTargetSwap, Vector2.Zero, Color.White);
        //        //}

        //        //spriteBatch.Draw(Main.screenTargetSwap, Vector2.Zero, Color.White);
        //        //spriteBatch.Draw(render, Vector2.Zero, Color.White);
        //        spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, sampler, DepthStencilState.Default, RasterizerState.CullNone, null, trans * 2);
        //    }
        //}
        public Player Player => Main.player[projectile.owner];
        public override void AI()
        {
            if (projectile.ai[0] == 0)
            {
                projectile.velocity *= 0.9f;
                //var length = projectile.velocity.Length();
                if (projectile.velocity != Vector2.Zero)
                {
                    projectile.rotation = projectile.velocity.ToRotation();
                }
                if (projectile.velocity.Length() < 2f)
                {
                    projectile.ai[1]++;
                }
                if (projectile.timeLeft == 30)
                {
                    for (int i = 0; i < 30; i++)
                    {
                        Dust d = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height,
                            MyDustId.Fire, 0, 0, 100, Color.White, 1.5f);
                        d.noGravity = true;
                        d.velocity *= 2;
                        Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);

                    }
                    SoundEngine.PlaySound(Terraria.ID.SoundID.Item74);

                    if (projectile.ai[0] == 0)
                    {
                        var p1 = Projectile.NewProjectileDirect(projectile.GetSource_FromThis(), projectile.Center, default, projectile.type, projectile.damage, 5f, projectile.owner, 1);
                        p1.height = p1.width = 160;
                        p1.timeLeft = 2;
                        p1.Center = projectile.Center;
                        p1.penetrate = -1;
                    }
                    //else
                    //    SoundEngine.PlaySound(Terraria.ID.SoundID.Item38);
                    projectile.damage = 0;
                    for (int n = 0; n < 3; n++)
                    {
                        var swoosh = swooshes[n] = new();
                        swoosh.timeLeft = 30;
                        swoosh.xScaler = Main.rand.NextFloat(1, 3);
                        swoosh.rotation = Main.rand.NextFloat(0, MathHelper.TwoPi);
                        swoosh.center = projectile.Center;
                        swoosh.direction = (byte)Main.rand.Next(2);
                    }
                }
                if (projectile.timeLeft < 31)
                {
                    for (int n = 0; n < 5; n++)
                    {
                        var swoosh = swooshes[n];
                        if (swoosh != null && swooshes[n].timeLeft > 0) swoosh.timeLeft--;
                    }
                    VirtualDreamPlayer.screenShakeStrength += (projectile.timeLeft / 30f).HillFactor(1);
                }
                //Main.NewText(projectile.penetrate);
                //if (projectile.timeLeft < 147)
                //{
                //    //if (length > 2f)
                //    //{
                //    //    Dust.NewDustDirect(projectile.Center, projectile.width, projectile.height, MyDustId.Fire, 0f, 0f, 100, default(Color)).noGravity = true;
                //    //}
                //    var xScaler = MathHelper.Clamp(6 - length / 4, 1, 4);
                //    //var dirVec = projectile.velocity == default ? projectile.rotation.ToRotationVector2() : projectile.velocity / length;
                //    var baseVec = (projectile.timeLeft / 60f * MathHelper.Pi).ToRotationVector2() * new Vector2(1, 0.75f);
                //    var vec = new Vector2(baseVec.X - baseVec.Y, baseVec.X + baseVec.Y) * 0.707f;
                //    //for (int n = 0; n < 4; n++)
                //    //{
                //    //    Dust.NewDustPerfect(projectile.Center + (vec / new Vector2(xScaler, 1)).RotatedBy(projectile.rotation) * 128 * projectile.timeLeft / 150f, MyDustId.Fire, default,Scale:2).noGravity = true;
                //    //    vec = new Vector2(vec.Y, -vec.X);
                //    //}
                //    //Dust.NewDustPerfect(projectile.Center + (-vec / new Vector2(1, xScaler)).RotatedBy(projectile.rotation), MyDustId.OrangeBubble);

                //}
            }

        }
        public SolusKatanaProj.LeftSwoosh[] swooshes = new SolusKatanaProj.LeftSwoosh[5];
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Center += projectile.velocity;
            projectile.velocity *= 0f;
            return false;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.OnFire, 150);
            target.AddBuff(BuffID.Daybreak, 150);
            target.immune[projectile.owner] = 0;
            if (projectile.ai[0] == 0)
            {
                projectile.timeLeft = 31;
                //projectile.damage = 0;
            }
            //else 
            //{
            //    Main.NewText(projectile.penetrate);
            //}
        }
    }
    public class SolarGlobalProj : GlobalProjectile
    {
        public override bool PreDraw(Projectile projectile, ref Color lightColor)
        {
            List<CustomVertexInfo> bars = new List<CustomVertexInfo>();
            List<int> indexer = new List<int>();
            Player player = null;
            foreach (var proj in Main.projectile)
            {
                if (proj.active && proj.ModProjectile != null && proj.ModProjectile is SolusEnergyShard shard)
                {
                    foreach (var swoosh in shard.swooshes)
                    {
                        if (swoosh != null && swoosh.Active)
                        {
                            for (int i = 0; i < 25; i++)
                            {
                                var f = i / 24f;
                                var lerp = f.Lerp(1 - swoosh.timeLeft / 30f, 1);
                                float theta2 = (1.8375f * lerp - 1.125f) * MathHelper.Pi + MathHelper.Pi;
                                if (swoosh.direction == 1) theta2 = MathHelper.TwoPi - theta2;
                                var scaler = 50 * shard.Player.GetAdjustedItemScale(shard.Player.HeldItem) / (float)Math.Sqrt(swoosh.xScaler) * (Main.GameViewMatrix != null ? Main.GameViewMatrix.TransformationMatrix : Matrix.Identity).M11 * .5f;
                                Vector2 newVec = -2 * (theta2.ToRotationVector2() * new Vector2(swoosh.xScaler, 1)).RotatedBy(swoosh.rotation) * scaler * (1 + (1 - swoosh.timeLeft / 30f));
                                var realColor = Color.Lerp(Color.White, Color.Orange, f);
                                realColor.A = (byte)((1 - f).HillFactor2(1) * swoosh.timeLeft / 30f * 255);
                                bars.Add(new CustomVertexInfo(swoosh.center + newVec, realColor, new Vector3(1 - f, 1, 0.6f)));
                                realColor.A = 0;
                                bars.Add(new CustomVertexInfo(swoosh.center, realColor, new Vector3(0, 0, 0.6f)));
                            }
                            indexer.Add(bars.Count - 2);
                            player = shard.Player;
                        }
                    }
                }
            }
            if (bars.Count > 2)
            {
                var projection = Matrix.CreateOrthographicOffCenter(0, Main.screenWidth, Main.screenHeight, 0, 0, 1);
                var model = Matrix.CreateTranslation(new Vector3(-Main.screenPosition.X, -Main.screenPosition.Y, 0));
                RasterizerState originalState = Main.graphics.GraphicsDevice.RasterizerState;
                var trans = Main.GameViewMatrix != null ? Main.GameViewMatrix.TransformationMatrix : Matrix.Identity;

                SamplerState sampler = SamplerState.LinearClamp;
                CustomVertexInfo[] triangleList = new CustomVertexInfo[(bars.Count - 2) * 3];//
                for (int i = 0; i < bars.Count - 2; i += 2)
                {
                    if (indexer.ToArray().ContainsValue(i)) continue;
                    var k = i / 2;
                    if (6 * k < triangleList.Length)
                    {
                        triangleList[6 * k] = bars[i];
                        triangleList[6 * k + 1] = bars[i + 2];
                        triangleList[6 * k + 2] = bars[i + 1];
                    }
                    if (6 * k + 3 < triangleList.Length)
                    {
                        triangleList[6 * k + 3] = bars[i + 1];
                        triangleList[6 * k + 4] = bars[i + 2];
                        triangleList[6 * k + 5] = bars[i + 3];
                    }
                }
                //GraphicsDevice gd = Main.instance.GraphicsDevice;
                //RenderTarget2D render = IllusionBoundMod.Instance.render;
                SpriteBatch spriteBatch = Main.spriteBatch;
                spriteBatch.End();
                //gd.SetRenderTarget(render);
                //gd.Clear(Color.Transparent);
                spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.Additive, sampler, DepthStencilState.Default, RasterizerState.CullNone, null, trans * 2);//Main.DefaultSamplerState//Main.GameViewMatrix.TransformationMatrix
                IllusionBoundMod.ShaderSwooshEX.Parameters["uTransform"].SetValue(model * projection);
                IllusionBoundMod.ShaderSwooshEX.Parameters["uLighter"].SetValue(0);
                IllusionBoundMod.ShaderSwooshEX.Parameters["uTime"].SetValue(0);//-(float)Main.time * 0.06f
                IllusionBoundMod.ShaderSwooshEX.Parameters["checkAir"].SetValue(true);
                IllusionBoundMod.ShaderSwooshEX.Parameters["airFactor"].SetValue(1);
                IllusionBoundMod.ShaderSwooshEX.Parameters["gather"].SetValue(true);
                Main.graphics.GraphicsDevice.Textures[0] = IllusionBoundMod.GetTexture("Images/BaseTex_7");
                Main.graphics.GraphicsDevice.Textures[1] = IllusionBoundMod.GetTexture("Images/AniTex");
                Main.graphics.GraphicsDevice.Textures[2] = TextureAssets.Item[player.HeldItem.type].Value;
                Main.graphics.GraphicsDevice.Textures[3] = IllusionBoundMod.HeatMap[24];

                Main.graphics.GraphicsDevice.SamplerStates[0] = sampler;
                Main.graphics.GraphicsDevice.SamplerStates[1] = sampler;
                Main.graphics.GraphicsDevice.SamplerStates[2] = sampler;
                Main.graphics.GraphicsDevice.SamplerStates[2] = sampler;

                IllusionBoundMod.ShaderSwooshEX.CurrentTechnique.Passes[2].Apply();
                Main.graphics.GraphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleList, triangleList, 0, bars.Count - 2);
                Main.graphics.GraphicsDevice.RasterizerState = originalState;
                spriteBatch.End();
                //Main.spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
                spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, sampler, DepthStencilState.Default, RasterizerState.CullNone, null, trans * 2);//Main.DefaultSamplerState//Main.GameViewMatrix.TransformationMatrix

                //IllusionBoundMod.Distort.Parameters["offset"].SetValue(new Vector2(Main.screenWidth, Main.screenHeight));
                //IllusionBoundMod.Distort.Parameters["tex0"].SetValue(render);

                //IllusionBoundMod.Distort.Parameters["position"].SetValue(new Vector2(0, 2.5f));
                //IllusionBoundMod.Distort.Parameters["tier2"].SetValue(0.05f);
                //for (int n = 0; n < 1; n++)
                //{
                //    gd.SetRenderTarget(Main.screenTargetSwap);
                //    gd.Clear(Color.Transparent);
                //    IllusionBoundMod.Distort.CurrentTechnique.Passes[7].Apply();
                //    spriteBatch.Draw(Main.screenTarget, Vector2.Zero, Color.White);



                //    gd.SetRenderTarget(Main.screenTarget);
                //    gd.Clear(Color.Transparent);
                //    IllusionBoundMod.Distort.CurrentTechnique.Passes[6].Apply();
                //    spriteBatch.Draw(Main.screenTargetSwap, Vector2.Zero, Color.White);
                //}
                //IllusionBoundMod.Distort.Parameters["position"].SetValue(new Vector2(0, 2.5f));
                //IllusionBoundMod.Distort.Parameters["ImageSize"].SetValue(projectile.rotation.ToRotationVector2() * -0.006f);
                //for (int n = 0; n < 1; n++)
                //{
                //    gd.SetRenderTarget(Main.screenTargetSwap);
                //    gd.Clear(Color.Transparent);
                //    IllusionBoundMod.Distort.CurrentTechnique.Passes[5].Apply();
                //    spriteBatch.Draw(Main.screenTarget, Vector2.Zero, Color.White);

                //    gd.SetRenderTarget(Main.screenTarget);
                //    gd.Clear(Color.Transparent);
                //    IllusionBoundMod.Distort.CurrentTechnique.Passes[4].Apply();
                //    spriteBatch.Draw(Main.screenTargetSwap, Vector2.Zero, Color.White);
                //}

                //spriteBatch.Draw(Main.screenTargetSwap, Vector2.Zero, Color.White);
                //spriteBatch.Draw(render, Vector2.Zero, Color.White);
                //spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, sampler, DepthStencilState.Default, RasterizerState.CullNone, null, trans * 2);
            }
            return base.PreDraw(projectile, ref lightColor);
        }
    }
}