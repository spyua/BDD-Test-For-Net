# BDD-WorkShop-Test
Practice BDD development using SpecFlow and SpecFlow.NUnit.

# Requirement

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
