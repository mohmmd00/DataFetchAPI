import os
from locust import HttpUser, task, between

class WebsiteUser(HttpUser):
    wait_time = between(1, 5)
    product_id = os.getenv("PRODUCT_ID", 1)  

    @task
    def get_all_products(self):
        self.client.get("/api/Products")

    @task
    def get_selected_product(self):
        self.client.get(f"/api/Products/{self.product_id}")

    @task
    def get_recommendation_list(self):
        self.client.get(f"/api/Products/{self.product_id}/recommendation")

if __name__ == "__main__":
    import os
    os.system("locust -f locustfile.py")