# KỊCH BẢN GAME — SPACE EXPLORER: AURORA

> Tài liệu thiết kế gameplay, cốt truyện và kịch bản demo cho game Unity 2D.  
> Phiên bản định hướng: **Space Exploration + Shooter + Collecting + Boss Battle**

---

# 1. TỔNG QUAN GAME

## 1.1. Tên game

**SPACE EXPLORER: AURORA**

Người chơi điều khiển tàu thám hiểm **Aurora**, khám phá những vùng không gian chưa được con người biết đến.

Không giống một game bắn súng tuyến tính, người chơi có thể:

- Di chuyển tự do theo **4 hướng**.
- Khám phá các khu vực khác nhau trong bản đồ.
- Né hoặc phá thiên thạch.
- Chiến đấu với quái vật ngoài hành tinh.
- Thu thập **Star Crystal**.
- Thu thập các vật phẩm đặc biệt.
- Tìm các tài nguyên ẩn.
- Sử dụng power-up để tăng khả năng chiến đấu.
- Mở khóa khu vực mới.
- Tìm đường tiến tới vùng không gian tiếp theo.
- Đối đầu với Boss cuối mỗi hành trình.

Gameplay chính:

**EXPLORE → COLLECT → FIGHT → UPGRADE → DISCOVER → BOSS**

---

# 2. CỐT TRUYỆN

## 2.1. Bối cảnh

**Năm 2157.**

Trái Đất đang đứng trước cuộc khủng hoảng năng lượng nghiêm trọng.

Nguồn năng lượng hóa thạch gần như cạn kiệt, trong khi các nguồn năng lượng thay thế chưa đủ mạnh để duy trì nền văn minh.

Các nhà khoa học phát hiện một loại năng lượng bí ẩn tồn tại sâu trong không gian:

**Star Crystal — Tinh thể Sao.**

Tinh thể này có khả năng tạo ra năng lượng cực lớn và có thể cung cấp năng lượng cho Trái Đất trong hàng trăm năm.

Liên minh Thiên hà gửi tàu thám hiểm **Aurora** vào một khu vực chưa được khám phá.

Nhiệm vụ của người chơi:

> **Khám phá không gian, thu thập Star Crystal, tìm nguồn gốc của chúng và đưa Aurora trở về Trái Đất.**

Nhưng Aurora nhanh chóng phát hiện rằng khu vực này không hề trống rỗng.

Những sinh vật ngoài hành tinh đang bảo vệ Star Crystal.

Và càng tiến sâu vào không gian, Aurora càng phát hiện những dấu hiệu cho thấy:

> **Star Crystal không đơn giản chỉ là một nguồn năng lượng.**

---

# 3. CẤU TRÚC HÀNH TRÌNH

Thay vì mỗi màn chỉ là một dòng thiên thạch rơi từ trên xuống, game được chia thành **3 vùng khám phá**.

| Khu vực | Tên | Đặc điểm | Mục tiêu |
|---|---|---|---|
| 1 | Aurora Nebula | Tinh vân xanh tím | Làm quen + thu thập |
| 2 | Asteroid Frontier | Vành đai thiên thạch | Combat + khám phá |
| 3 | Black Hole Core | Lõi hố đen | Endgame + Boss |

Mỗi khu vực là một **khu vực khám phá có thể di chuyển tự do**.

Người chơi không nhất thiết phải đi theo một đường duy nhất.

Có thể:

- Đi sang trái.
- Đi sang phải.
- Bay lên.
- Bay xuống.
- Quay lại khu vực trước.
- Tìm vật phẩm.
- Né khu vực nguy hiểm.
- Chủ động tìm quái để chiến đấu.

---

# 4. GAMEPLAY LOOP

Gameplay chính của game:

```text
        ┌───────────────┐
        │    EXPLORE    │
        │  Khám phá map │
        └───────┬───────┘
                ↓
        ┌───────────────┐
        │    COLLECT    │
        │ Sao / Energy  │
        │   Item        │
        └───────┬───────┘
                ↓
        ┌───────────────┐
        │     FIGHT     │
        │ Asteroid /    │
        │ Alien Monster │
        └───────┬───────┘
                ↓
        ┌───────────────┐
        │    UPGRADE    │
        │ Shield / Gun  │
        │ Speed / Radar │
        └───────┬───────┘
                ↓
        ┌───────────────┐
        │   DISCOVER    │
        │ Khu vực mới   │
        └───────┬───────┘
                ↓
        ┌───────────────┐
        │     BOSS      │
        └───────┬───────┘
                ↓
             VICTORY
```

Điểm quan trọng:

**Người chơi không chỉ bắn để kiếm điểm.**

Người chơi phải **khám phá để tìm tài nguyên và tìm đường tiến tới mục tiêu tiếp theo.**

---

# 5. ĐIỀU KHIỂN

## 5.1. Di chuyển

Người chơi điều khiển Aurora bằng:

- `W` / `↑` — bay lên
- `S` / `↓` — bay xuống
- `A` / `←` — bay trái
- `D` / `→` — bay phải

Tàu có thể di chuyển tự do trong toàn bộ khu vực hiện tại.

Tốc độ cơ bản:

**8 units/second**

Có acceleration/deceleration nhẹ để tạo cảm giác tàu đang bay thay vì di chuyển như một sprite thông thường.

---

## 5.2. Bắn

Nhấn giữ:

**SPACE**

để bắn laser.

Tốc độ bắn cơ bản:

**0.35 giây/phát**

Người chơi có thể nâng cấp hoặc sử dụng Rapid-Fire để tăng tốc độ bắn.

---

## 5.3. Boost

Nhấn:

**SHIFT**

để sử dụng động cơ tăng tốc.

Boost giúp:

- Né đạn.
- Thoát khỏi quái.
- Di chuyển nhanh đến khu vực khác.
- Tạo cảm giác điều khiển spaceship thật hơn.

Boost sử dụng Energy.

---

# 6. HỆ THỐNG KHÁM PHÁ

## 6.1. Bản đồ

Mỗi khu vực được thiết kế như một **mini exploration map**.

```text
┌──────────────────────────────────────────┐
│                 SPACE                    │
│                                          │
│   ★       ☄             👾              │
│                                          │
│          ┌─────────┐                     │
│          │ PLAYER  │       ★             │
│          └─────────┘                     │
│                     ☄                    │
│                                          │
│   💎              👾             🔒      │
│                                          │
│                         → NEXT AREA      │
└──────────────────────────────────────────┘
```

Các khu vực trong map có thể chứa:

- Star Crystal.
- Asteroid.
- Monster.
- Power-up.
- Energy.
- Ancient Artifact.
- Secret area.
- Portal.
- Boss entrance.

---

# 7. HỆ THỐNG MỤC TIÊU

Mỗi vùng có một nhiệm vụ chính.

## Khu vực 1

**Collect 5 Star Crystals**

→ kích hoạt Navigation Beacon.

→ mở cổng sang khu vực tiếp theo.

## Khu vực 2

**Collect 10 Star Crystals + Destroy 8 Monsters**

→ thu thập đủ năng lượng để mở cổng.

→ mở đường tới Black Hole Core.

## Khu vực 3

**Find the Ancient Star Core**

→ kích hoạt Boss.

→ chiến đấu với Dreadnought.

---

# 8. STAR CRYSTAL

Star Crystal là vật phẩm quan trọng nhất trong game.

Sprite:

`star_crystal.png`

Đặc điểm:

- Bay lơ lửng.
- Xoay liên tục.
- Có hiệu ứng phát sáng.
- Có thể nằm ở nhiều vị trí khác nhau trong map.
- Một số Crystal được đặt ở khu vực nguy hiểm.

Khi người chơi đến gần:

**Crystal tự động hút về phía tàu.**

Bán kính magnet mặc định:

**3 units**

## 8.1. Điểm

Mỗi Star Crystal:

**100 điểm**

Nếu thu thập liên tiếp trong 3 giây:

```text
Crystal 1 → ×1
Crystal 2 → ×2
Crystal 3 → ×3
Crystal 4 → ×4
```

Combo reset nếu quá 3 giây không thu thập Crystal.

---

# 9. HỆ THỐNG RESOURCE

## Energy Cell

Sprite:

`energy_cell.png`

Energy dùng để:

- Boost.
- Kích hoạt một số thiết bị.
- Mở cổng.
- Kích hoạt Ancient Artifact.

Energy Cell có thể tìm thấy trong quá trình khám phá.

Điều này khiến người chơi phải:

> **Tìm kiếm → Thu thập → Quản lý tài nguyên**

thay vì chỉ bắn mọi thứ trên màn hình.

---

# 10. CÁC VẬT PHẨM KHÁM PHÁ

Game có 4 nhóm vật phẩm.

## 10.1. Star Crystal

**+100 điểm**

Dùng để:

- Tăng score.
- Combo.
- Mở khóa khu vực.

## 10.2. Energy Cell

**+20 Energy**

Dùng cho Boost và các cơ chế tương tác.

## 10.3. Repair Kit

Sprite:

`repair_kit.png`

Khôi phục:

**+25% HP**

Repair Kit đặc biệt hữu ích sau các trận chiến.

## 10.4. Ancient Artifact

Sprite:

`ancient_artifact.png`

Đây là vật phẩm hiếm.

Khi thu thập:

- +500 điểm.
- Hiển thị thông báo.
- Có thể kích hoạt secret lore.
- Góp phần hoàn thành bộ sưu tập.

---

# 11. HỆ THỐNG ASTEROID

Asteroid không còn đơn giản là vật thể rơi từ trên xuống.

Asteroid xuất hiện tự nhiên trong các vùng không gian.

Chúng có thể:

- Bay ngang.
- Bay dọc.
- Bay chéo.
- Xoay.
- Trôi theo quỹ đạo.
- Xuất hiện thành cụm.

## 11.1. Ba kích thước

| Size | HP | Score | Khi phá |
|---|---:|---:|---|
| Large | 3 | 20 | Tách thành 2 Medium |
| Medium | 2 | 30 | Tách thành 2 Small |
| Small | 1 | 50 | Destroy |

---

# 12. HỆ THỐNG QUÁI VẬT

Quái vật là sinh vật ngoài hành tinh bảo vệ Star Crystal.

Game có 3 loại chính.

## 12.1. Chaser

HP:

**2**

Score:

**40**

AI:

- Phát hiện người chơi.
- Đuổi theo tàu.
- Thay đổi hướng theo vị trí người chơi.
- Có thể lao nhanh khi ở gần.

Mục đích:

**Ép người chơi phải di chuyển.**

---

# 13. GUNNER

HP:

**2**

Score:

**60**

AI:

- Giữ khoảng cách với người chơi.
- Di chuyển ngang.
- Bắn đạn plasma.
- Ưu tiên tấn công từ xa.

Người chơi phải:

**Né đạn + tìm góc bắn + phản công.**

---

# 14. TANK

HP:

**6**

Score:

**100**

AI:

- Di chuyển chậm.
- Có lượng HP cao.
- Không dễ bị tiêu diệt.
- Xuất hiện ở khu vực nguy hiểm.

Tank đóng vai trò:

**Heavy Enemy**

---

# 15. ENEMY SPAWN

Quái vật không xuất hiện liên tục ngay trước mặt người chơi.

Spawner sẽ tạo quái ở các vị trí xung quanh khu vực.

```text
        Monster
           ↓

Monster ← PLAYER → Monster

           ↑
        Monster
```

Điều này tạo cảm giác:

> **Người chơi đang bị bao vây trong không gian rộng.**

---

# 16. COMBAT SYSTEM

Combat không chỉ là bắn liên tục.

Người chơi phải lựa chọn:

### Strategy 1 — Né

Boost để tránh quái.

### Strategy 2 — Tấn công

Giữ khoảng cách và bắn.

### Strategy 3 — Hit & Run

Bắn Tank → Boost → quay lại → tiếp tục bắn.

### Strategy 4 — Thu thập

Chấp nhận nguy hiểm để lấy Star Crystal hoặc Artifact.

Điều này tạo ra sự lựa chọn giữa:

**SAFE PLAY vs RISK & REWARD**

---

# 17. POWER-UP

Game có 5 power-up.

| Power-up | Hiệu ứng | Thời gian |
|---|---|---:|
| Shield | Chặn 1 lần va chạm | 10s |
| Rapid-Fire | Tăng tốc độ bắn | 8s |
| Triple-Shot | Bắn 3 tia | 10s |
| Speed Boost | +40% tốc độ | 8s |
| Magnet | Tăng bán kính hút item ×3 | 8s |

---

# 18. SHIELD

Khi kích hoạt:

Một vòng năng lượng xuất hiện xung quanh Aurora.

Nếu va chạm:

```text
Asteroid / Monster
       ↓
    SHIELD
       ↓
Shield destroyed
       ↓
Player survives
```

Nếu không có Shield:

**Game Over**

---

# 19. TRIPLE-SHOT

Bắn:

```text
       ↑
      /
     ↑
      \
       ↑
```

Ba tia laser:

- Chính giữa.
- Chéo trái.
- Chéo phải.

Power-up này đặc biệt hiệu quả khi bị nhiều quái bao vây.

---

# 20. MAGNET

Magnet tăng bán kính hút vật phẩm:

**3 → 9 units**

Khi kích hoạt, các Star Crystal ở xa bắt đầu bay về Aurora.

Đây là power-up dành cho người chơi muốn:

**Farm Star Crystal + Combo**

---

# 21. UPGRADE SYSTEM

Star Crystal không chỉ dùng để tính điểm.

Sau mỗi khu vực, người chơi có thể sử dụng Crystal để nâng cấp Aurora.

Có 4 chỉ số:

| Upgrade | Hiệu ứng |
|---|---|
| Engine | Tăng tốc độ |
| Laser | Tăng damage |
| Shield | Tăng khả năng sống sót |
| Energy | Tăng Energy tối đa |

Ví dụ:

```text
AURORA UPGRADE

Engine       ★★★☆☆
Laser        ★★☆☆☆
Shield       ★★★☆☆
Energy       ★★☆☆☆

Star Crystal: 1250

[ UPGRADE ]
```

Điều này giúp người chơi có cảm giác:

> **Mình thực sự đang phát triển con tàu trong chuyến hành trình.**

---

# 22. KHU VỰC 1 — AURORA NEBULA

## Bối cảnh

Tinh vân xanh tím.

Không gian tương đối yên bình.

Mục đích:

**Tutorial + Exploration**

## Gameplay

Người chơi xuất hiện ở trung tâm.

Có thể tự do bay quanh khu vực.

Tìm:

- 5 Star Crystal.
- 2 Energy Cell.
- 1 Repair Kit.

Trong quá trình khám phá:

- Asteroid xuất hiện.
- Chaser bắt đầu xuất hiện.
- Người chơi học cách bắn và né.

## Objective

```text
MISSION

Collect Star Crystal
0 / 5

Energy
0 / 2

Find Navigation Beacon
LOCKED
```

Khi thu thập đủ 5 Crystal:

**Navigation Beacon được kích hoạt.**

Một cổng không gian xuất hiện.

→ Sang Area 2.

---

# 23. KHU VỰC 2 — ASTEROID FRONTIER

Đây là khu vực nguy hiểm hơn.

Background:

**Vành đai thiên thạch khổng lồ.**

Asteroid xuất hiện dày đặc hơn.

Monster:

- Chaser.
- Gunner.
- Tank.

## Objective

Người chơi phải:

**Collect 10 Star Crystals**

và

**Destroy 8 Monsters**

Sau khi hoàn thành:

→ tìm **Warp Gate**

→ kích hoạt cổng bằng Energy.

## Điểm thú vị

Warp Gate không nằm ngay cạnh người chơi.

Người chơi phải:

**Explore map → tìm Gate → tìm Energy → quay lại Gate → activate**

Điều này làm cho game có cảm giác khám phá thực sự.

---

# 24. SECRET AREA

Trong Area 2 có một khu vực bí mật.

```text
        NORMAL AREA

             ↓

       [ ASTEROIDS ]

             ↓

      ┌─────────────┐
      │ SECRET ZONE │
      │             │
      │  ⭐ Artifact │
      │             │
      └─────────────┘
```

Nếu người chơi khám phá đủ sâu:

→ tìm thấy **Ancient Artifact**.

Reward:

**+500 Score**

và mở một đoạn lore ngắn.

---

# 25. KHU VỰC 3 — BLACK HOLE CORE

Đây là khu vực cuối.

Background:

**Hố đen khổng lồ + không gian tím đen.**

Không gian bị ảnh hưởng bởi lực hấp dẫn.

Gameplay:

- Asteroid bay nhanh.
- Monster spawn nhiều.
- Enemy bullet nhanh hơn.
- Có những vùng nguy hiểm.

Người chơi phải tìm:

**Ancient Star Core**

Khi tìm thấy:

```text
WARNING

UNKNOWN ENERGY SIGNATURE DETECTED

          ↓

     BOSS INCOMING
```

---

# 26. FINAL BOSS — DREADNOUGHT

Dreadnought là chiến hạm của một nền văn minh ngoài hành tinh cổ đại.

HP:

**40**

Score:

**1000**

Boss xuất hiện sau khi người chơi kích hoạt Ancient Star Core.

---

# 27. BOSS PHASE 1

Dreadnought bay quanh khu vực.

Attack:

### Fan Shot

Bắn nhiều đạn theo hình quạt.

Người chơi phải:

**di chuyển liên tục để né.**

---

# 28. BOSS PHASE 2

Khi HP còn:

**60%**

Boss bắt đầu triệu hồi Chaser.

Người chơi phải quyết định:

- Tập trung bắn Boss.
- Hay tiêu diệt quái nhỏ trước.

---

# 29. BOSS PHASE 3 — ENRAGE

Khi HP còn:

**30%**

Dreadnought chuyển sang trạng thái:

**ENRAGE**

Hiệu ứng:

- Boss phát sáng.
- Attack speed +35%.
- Enemy bullet nhanh hơn.
- Charge attack xuất hiện.

---

# 30. CHARGE ATTACK

Boss nhắm vào vị trí hiện tại của Aurora.

Boss chuyển sang màu cảnh báo:

**0.5 giây**

Sau đó lao thẳng tới.

Người chơi phải:

**BOOST + đổi hướng**

để né.

Đây là khoảnh khắc quan trọng nhất của Boss Fight.

---

# 31. BOSS DEFEATED

Khi HP Dreadnought:

**0**

Boss phát nổ.

Màn hình:

```text
        DREADNOUGHT DESTROYED

              +1000

       STAR CORE ACQUIRED

             VICTORY
```

---

# 32. KẾT THÚC CỐT TRUYỆN

Aurora tiến vào trung tâm của Black Hole Core.

Người chơi phát hiện nguồn năng lượng của Star Crystal.

Nhưng thay vì chỉ là một loại khoáng vật tự nhiên, Star Crystal là:

> **năng lượng được tạo ra bởi lõi của một nền văn minh cổ đại.**

Aurora thu thập Star Core và truyền dữ liệu về Trái Đất.

Nhiệm vụ hoàn thành.

---

# 33. HỆ THỐNG SCORE

| Hành động | Score |
|---|---:|
| Destroy Small Asteroid | +50 |
| Destroy Medium Asteroid | +30 |
| Destroy Large Asteroid | +20 |
| Destroy Chaser | +40 |
| Destroy Gunner | +60 |
| Destroy Tank | +100 |
| Star Crystal | +100 × Combo |
| Ancient Artifact | +500 |
| Dreadnought | +1000 |

---

# 34. HEALTH SYSTEM

Aurora có:

**100 HP**

| Nguy hiểm | Damage |
|---|---:|
| Small Asteroid | 25 |
| Medium Asteroid | 35 |
| Large Asteroid | 50 |
| Chaser | 30 |
| Enemy Bullet | 20 |
| Boss Charge | 60 |

Shield có thể chặn hoàn toàn một lần va chạm.

---

# 35. HUD

HUD hiển thị:

- Score.
- Combo.
- HP.
- Energy.
- Shield.
- Current Area.
- Mission Objective.

Ví dụ:

```text
┌─────────────────────────────────────┐
│ SCORE: 2450       ⭐ ×3             │
│                                     │
│ HP ████████░░       SHIELD ●        │
│ ENERGY ██████░░     BOOST READY     │
│                                     │
│         SPACE EXPLORER              │
│                                     │
│              🚀                     │
│                                     │
│       👾                 ☄          │
│                                     │
│    ⭐                💎              │
│                                     │
│                          AREA 2      │
└─────────────────────────────────────┘
```

---

# 36. MINI MAP

Để nhấn mạnh yếu tố **exploration**, có thể thêm minimap ở góc màn hình.

Minimap hiển thị:

- Vị trí Aurora.
- Star Crystal.
- Monster.
- Warp Gate.
- Boss.
- Secret Area.

---

# 37. TẠI SAO GAME NÀY THỰC SỰ LÀ EXPLORATION?

Game có 5 yếu tố exploration:

### 1. Free Movement

Người chơi tự do di chuyển 4 hướng.

### 2. Multiple Locations

Map có nhiều khu vực.

### 3. Hidden Collectibles

Một số Star Crystal và Artifact nằm ở những vị trí khó tìm.

### 4. Objectives

Người chơi phải tìm tài nguyên và hoàn thành nhiệm vụ để mở khóa khu vực mới.

### 5. Discovery

Người chơi không biết tất cả mọi thứ ngay từ đầu.

Phải:

**Khám phá → phát hiện → thu thập → mở khóa → tiến sâu hơn.**

---

# 38. REPLAY VALUE

Sau khi hoàn thành game, người chơi có thể chơi lại để:

- Tìm toàn bộ Artifact.
- Tìm toàn bộ Star Crystal.
- Đạt High Score.
- Hoàn thành nhanh hơn.
- Không mất HP.
- Thu thập đủ các vật phẩm.
- Thử các cách nâng cấp tàu khác nhau.

---

# 39. CẤU TRÚC SCRIPT UNITY

```text
Scripts
│
├── Player
│   ├── PlayerController.cs
│   ├── PlayerCombat.cs
│   ├── PlayerHealth.cs
│   └── PlayerEnergy.cs
│
├── Combat
│   ├── Bullet.cs
│   ├── EnemyBullet.cs
│   ├── DamageSystem.cs
│   └── Explosion.cs
│
├── Enemy
│   ├── Asteroid.cs
│   ├── Monster.cs
│   ├── ChaserAI.cs
│   ├── GunnerAI.cs
│   ├── TankAI.cs
│   └── BossController.cs
│
├── Exploration
│   ├── ExplorationManager.cs
│   ├── AreaManager.cs
│   ├── MissionManager.cs
│   ├── WarpGate.cs
│   ├── SecretArea.cs
│   └── MiniMapController.cs
│
├── Collectibles
│   ├── StarPickup.cs
│   ├── EnergyPickup.cs
│   ├── RepairKit.cs
│   └── AncientArtifact.cs
│
├── PowerUps
│   └── PowerUp.cs
│
├── Spawn
│   ├── AsteroidSpawner.cs
│   ├── MonsterSpawner.cs
│   └── PickupSpawner.cs
│
├── Game
│   ├── GameManager.cs
│   ├── ScoreManager.cs
│   ├── UpgradeManager.cs
│   └── SaveManager.cs
│
└── UI
    ├── HUDController.cs
    ├── MainMenuController.cs
    ├── PauseController.cs
    ├── GameOverController.cs
    └── VictoryController.cs
```

---

# 40. FLOW CỦA GAME

```text
MAIN MENU
    ↓
NEW GAME
    ↓
AREA 1
    ↓
Explore
    ↓
Collect Stars
    ↓
Fight Chaser
    ↓
Find Navigation Beacon
    ↓
AREA 2
    ↓
Explore
    ↓
Fight Monsters
    ↓
Collect Energy
    ↓
Find Secret Area
    ↓
Find Warp Gate
    ↓
AREA 3
    ↓
Explore Black Hole Core
    ↓
Find Ancient Star Core
    ↓
DREADNOUGHT
    ↓
Boss Fight
    ↓
VICTORY
```

---

# 41. CÁC ĐIỂM NHẤN SÁNG TẠO

1. **Exploration + Shooter** — Không chỉ bắn asteroid mà người chơi phải khám phá map.
2. **Free 4-direction Movement** — Spaceship thực sự bay trong không gian theo nhiều hướng.
3. **Risk & Reward** — Vật phẩm giá trị thường nằm ở những khu vực nguy hiểm.
4. **Resource Management** — Energy được sử dụng cho Boost và mở khóa.
5. **Upgrade System** — Star Crystal hỗ trợ nâng cấp Aurora.
6. **Enemy AI** — Ba loại quái có hành vi khác nhau.
7. **Secret Area** — Khuyến khích người chơi khám phá.
8. **Dynamic Difficulty** — Game tăng độ khó theo tiến trình.
9. **Boss Fight** — Boss có nhiều phase và pattern.
10. **Replayability** — Có lý do để chơi lại sau khi hoàn thành.

---

# 42. MAPPING TIÊU CHÍ CHẤM ĐIỂM

| Tiêu chí | Tính năng |
|---|---|
| Player Control | WASD + 4 hướng + Boost |
| Combat | Laser + Triple Shot |
| Enemy | Asteroid + 3 Monster AI |
| Collision | Damage + Shield |
| Collectible | Star + Energy + Artifact |
| Exploration | Free movement + Map + Secret Area |
| Objective | Mission system |
| Progression | Area 1 → Area 2 → Area 3 |
| Upgrade | Engine / Laser / Shield / Energy |
| Spawning | Dynamic Asteroid + Monster |
| Boss | Dreadnought 3 Phase |
| Score | Score + Combo |
| Save | High Score + Progress |
| UI | HUD + Mission + Minimap |
| Pause | ESC / P |
| Scene | Main Menu / Gameplay / Victory / Game Over |

---

# 43. KỊCH BẢN DEMO 5–7 PHÚT

## 0:00 – 0:30 — STORY

Mở Main Menu.

Nói:

> "Năm 2157, Trái Đất đang cạn kiệt năng lượng. Em điều khiển tàu Aurora để khám phá những vùng không gian chưa được biết đến, thu thập Star Crystal và tìm nguồn năng lượng có thể cứu Trái Đất."

## 0:30 – 1:30 — FREE MOVEMENT

Bấm New Game.

Cho tàu bay:

- Lên.
- Xuống.
- Trái.
- Phải.

Nói:

> "Điểm khác biệt chính của game là người chơi không bị giới hạn vào việc né các vật thể rơi xuống. Spaceship có thể tự do khám phá khu vực theo bốn hướng."

## 1:30 – 2:15 — COMBAT

Gặp Asteroid.

Giữ Space.

Bắn:

Large → Medium → Small.

Sau đó gặp Chaser.

Né và bắn quái.

Nói:

> "Trong quá trình khám phá, người chơi phải đối mặt với cả thiên thạch và quái vật ngoài hành tinh."

## 2:15 – 3:00 — COLLECT

Thu thập:

- Star Crystal.
- Energy Cell.
- Power-up.

Khoe combo.

Nói:

> "Star Crystal vừa mang lại điểm số vừa là tài nguyên quan trọng trong quá trình khám phá. Người chơi có thể mạo hiểm đi vào khu vực nguy hiểm để lấy những vật phẩm có giá trị cao hơn."

## 3:00 – 3:45 — EXPLORATION

Mở minimap.

Bay tới một khu vực khác.

Tìm Warp Gate.

Nói:

> "Người chơi phải chủ động tìm mục tiêu trên bản đồ. Một số khu vực không bắt buộc nhưng chứa các vật phẩm bí mật."

## 3:45 – 4:30 — SECRET AREA

Tìm Ancient Artifact.

Hiện:

```text
ANCIENT ARTIFACT FOUND
+500 SCORE
```

Nói:

> "Đây là một khu vực bí mật. Người chơi không cần tìm nó để hoàn thành màn chơi, nhưng nếu khám phá được thì sẽ nhận phần thưởng."

## 4:30 – 5:00 — AREA 2

Kích hoạt Warp Gate.

Chuyển sang Area 2.

Background thay đổi.

Quái nhiều hơn.

Nói:

> "Sau khi hoàn thành nhiệm vụ, người chơi mở khóa khu vực mới. Mỗi khu vực không chỉ thay đổi background mà còn thay đổi độ khó và loại enemy."

## 5:00 – 6:00 — BOSS

Vào Area 3.

Tìm Ancient Star Core.

Boss xuất hiện.

Demo:

- Fan Shot.
- Summon.
- Charge.
- Enrage.

Nói:

> "Đây là Dreadnought, Boss cuối. Boss có nhiều pattern và thay đổi hành vi khi lượng máu giảm."

## 6:00 – 6:30 — VICTORY

Hạ Boss.

Hiện Victory.

Nói:

> "Sau khi đánh bại Dreadnought, người chơi thu được Star Core và hoàn thành nhiệm vụ của Aurora."

---

# 44. CÂU KẾT THÚC THUYẾT TRÌNH

> **"Điểm em muốn tập trung vào trong game là cảm giác khám phá. Người chơi không chỉ điều khiển spaceship để bắn và né, mà phải tự di chuyển trong không gian, tìm kiếm tài nguyên, chiến đấu với các sinh vật bảo vệ chúng, khám phá khu vực bí mật và đưa ra quyết định giữa việc tiếp tục khám phá để nhận phần thưởng hoặc đi thẳng tới mục tiêu. Vì vậy gameplay được xây dựng theo vòng lặp Explore → Collect → Fight → Upgrade → Discover → Boss."**

---

# 45. PHẠM VI PHÁT TRIỂN THỰC TẾ

Để đảm bảo game **làm được trong Unity và không bị quá tải**, phiên bản đầu tiên nên triển khai theo thứ tự:

## PHASE 1 — Core Movement

- Spaceship.
- WASD.
- 4-direction movement.
- Camera.
- Boundary.

## PHASE 2 — Combat

- Laser.
- Asteroid.
- Collision.
- Explosion.

## PHASE 3 — Exploration

- Map lớn hơn camera.
- Camera follow.
- Các khu vực.
- Warp Gate.

## PHASE 4 — Collecting

- Star Crystal.
- Energy Cell.
- Repair Kit.
- Artifact.

## PHASE 5 — Enemy

- Chaser.
- Gunner.
- Tank.

## PHASE 6 — Mission

- Collect X stars.
- Kill X monsters.
- Find Gate.
- Activate Gate.

## PHASE 7 — Upgrade

- Engine.
- Laser.
- Shield.
- Energy.

## PHASE 8 — Boss

- Dreadnought.
- Fan Shot.
- Summon.
- Charge.
- Enrage.

## PHASE 9 — UI

- HUD.
- Mission tracker.
- Minimap.
- Pause.
- Game Over.
- Victory.

## PHASE 10 — Polish

- Sound.
- VFX.
- Parallax.
- Screen shake.
- Camera effects.
- Transitions.

---

# 46. TÓM TẮT Ý TƯỞNG

**SPACE EXPLORER: AURORA** là game Unity 2D kết hợp:

**Space Exploration**
+
**Shooter Combat**
+
**Collecting**
+
**Resource Management**
+
**Upgrade**
+
**Enemy AI**
+
**Boss Battle**

Gameplay cốt lõi:

> **Bay tự do → khám phá → tìm tài nguyên → thu thập Star Crystal → chiến đấu với asteroid/quái → nâng cấp tàu → tìm khu vực bí mật → mở khóa vùng mới → tiến vào Black Hole Core → đánh Dreadnought → hoàn thành nhiệm vụ.**
