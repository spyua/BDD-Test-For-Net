Feature: Add item to cart
    In order to avoid the wrong total price
    As a Customer
    I want to get the current total price of items in the cart

Scenario: Calculate the total price for cart items
    Given there are cart items
    When the customer completes the order
    Then the total price should be the sum of the subtotal of all the cart items plus shipping fee NTD 60

Scenario: Alert customer when adding too many items
    Given there are five items in the cart
    When the customer tries to add one more item
    Then the system should alert the customer not to do so and indicate which item cannot be added

Scenario: Alert customer when exceeding purchase limit
    Given the customer has added a quantity of items to the cart
    When the quantity of items exceeds the purchase limit
    Then the system should alert the customer and indicate that the item has reached its purchase limit

Scenario: Apply free shipping for orders over 500
    Given the customer selects the cart items
    When the total price is over 500
    Then the customer should receive free shipping
