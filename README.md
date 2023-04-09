# BDD Test
Practice BDD development using SpecFlow and SpecFlow.NUnit.

# Requirement (English)

This is an online stationery store, a place where you can buy stationery conveniently.
Currently, we're going to develop one of the key features: add products to the cart.

## Feature: Add products to the cart

The customer can add the product with desired quantity to the cart, we call it a cart item, and then the customer can get the total price of the cart.
Also, the customer can only add one cart item at a time.

A product has the following attributes:

1. name, which should be unique
2. unit price (NTD, the amount should always be an integer)
3. the maximum purchase quantity

For now, the product owner provide a list of specifications:

1. The total of the cart is the sum of the subtotal of all the cart items plus shipping fee NTD 60
2. A cart can only have maximum of 5 cart items at a time, if the customer try to add one more, the system would reject the request and alert the customer that which item is rejected.
3. The quantity of the added cart item should not surpass the maximum purchase quantity of that product.
4. Free shipping if the cart total is over 500.

### Current Price List (for reference)

| Name             | Unit Price | Max Purchase Qty |
|------------------|------------|------------------|
| Eraser           | 10         | 10               |
| Pencil           | 20         | 10               |
| Blue Pen         | 30         | 10               |
| Ruler            | 35         | 10               |
| Notebook         | 50         | 5                |
| Pencil Sharpener | 200        | 2                |
| Computer Mouse   | 500        | 1                |
| Keyboard         | 800        | 1                |

---

# Requirement(中文)

這是一家線上文具商店，提供客戶方便購買文具的服務。
今天我們要開發其中的一個關鍵功能：將商品加入購物車。

## 功能：加商品至購物車

客人可以把商品以及欲購買數量加入購物 (我們稱之爲一個商品細項)，並得到目前的購物車總金額。
一次只能加入一個商品細項（商品以及指定數量）

一個商品有以下資料：

1. 名稱，不會有重複名稱
2. 單價，以 NTD 計算
3. 最大購買數量

此外，該功能需要滿足這些規則：

1. 購物車金總價是每一細項的總和，一個細項是商品單價乘上數量，加上物流費 60 元
2. 購物車最多只能有 5 種商品，如果超過，要警示客人不能這樣做，並標示出是哪一項商品不能加入。
3. 加入的商品數量不可以超商品可購買上限，如果超過，要警示客人，並標示出該商品已經到達購買上限
4. 超過 500 元則免運費

### 目前商品列表：

| Name             | Unit Price | Max Purchase Qty |
|------------------|------------|------------------|
| Eraser           | 10         | 10               |
| Pencil           | 20         | 10               |
| Blue Pen         | 30         | 10               |
| Ruler            | 35         | 10               |
| Notebook         | 50         | 5                |
| Pencil Sharpener | 200        | 2                |
| Computer Mouse   | 500        | 1                |
| Keyboard         | 800        | 1                |

