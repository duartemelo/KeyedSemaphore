# Keyed Semaphore Implementation

## Race Conditions and Semaphores

Imagine that you have two users trying to register in your application using the same email at the same time. They would hit your endpoint, your service would query the database to check if there is already a user with that specific email, and the database would respond that there isn’t any user with that email, since neither of them has been created yet.

Then, both users with the same email would be inserted into your database, leaving your application in an invalid state, thereby breaking a business rule.

Yes, you could add a unique constraint to your database, but in some specific cases, you might want to lock the operation of registering an entity to prevent race conditions. In this case, we would want to lock the registration of a user if multiple users are trying to register with the same email.

To address this, I created a simple implementation of a Keyed Semaphore, where you can have a semaphore associated with a certain key (for example, a user's email). This way, you only lock the registration of a user if there are multiple attempts to register with the same email (the key of your semaphore!).

There are many other ways to prevent race conditions, but keyed semaphores are a simple way to prevent them in non-distributed applications.