#!/usr/bin/env python3
"""
פיילוט פשוט לאפליקציית חיסכון בסל קניות.

מה הפיילוט מדגים:
1) קבלת אזור + רשימת מוצרים.
2) "סריקה" של סופרמרקטים באזור (דאטה מדומה לפיילוט).
3) בניית סל מינימלי במחיר, כולל פיצול אוטומטי בין כמה חנויות.
"""

from __future__ import annotations

from dataclasses import dataclass
from typing import Dict, List, Tuple


@dataclass(frozen=True)
class Store:
    name: str
    area: str
    prices: Dict[str, float]


# דאטה מדומה לפיילוט בישראל (₪)
STORES: List[Store] = [
    Store(
        name="רמי לוי - תל אביב",
        area="תל אביב",
        prices={
            "חלב 3% 1 ליטר": 6.20,
            "לחם אחיד": 5.40,
            "ביצים L 12 יחידות": 14.90,
            "אורז 1 ק\"ג": 8.50,
            "פסטה 500 גרם": 5.90,
            "עגבניות 1 ק\"ג": 6.50,
            "מלפפונים 1 ק\"ג": 6.70,
            "חזה עוף 1 ק\"ג": 38.90,
            "גבינה לבנה 250 גרם": 5.80,
            "שמן קנולה 1 ליטר": 13.90,
        },
    ),
    Store(
        name="שופרסל דיל - תל אביב",
        area="תל אביב",
        prices={
            "חלב 3% 1 ליטר": 6.60,
            "לחם אחיד": 7.20,
            "ביצים L 12 יחידות": 15.50,
            "אורז 1 ק\"ג": 6.20,
            "פסטה 500 גרם": 6.10,
            "עגבניות 1 ק\"ג": 7.90,
            "מלפפונים 1 ק\"ג": 5.80,
            "חזה עוף 1 ק\"ג": 39.50,
            "גבינה לבנה 250 גרם": 6.40,
            "שמן קנולה 1 ליטר": 11.90,
        },
    ),
    Store(
        name="ויקטורי - תל אביב",
        area="תל אביב",
        prices={
            "חלב 3% 1 ליטר": 6.10,
            "לחם אחיד": 7.10,
            "ביצים L 12 יחידות": 14.40,
            "אורז 1 ק\"ג": 8.20,
            "פסטה 500 גרם": 5.60,
            "עגבניות 1 ק\"ג": 8.30,
            "מלפפונים 1 ק\"ג": 6.40,
            "חזה עוף 1 ק\"ג": 37.90,
            "גבינה לבנה 250 גרם": 5.70,
            "שמן קנולה 1 ליטר": 13.50,
        },
    ),
]


def optimize_basket(area: str, products: List[str]) -> Tuple[Dict[str, List[Tuple[str, float]]], float]:
    local_stores = [store for store in STORES if store.area == area]
    if not local_stores:
        raise ValueError(f"לא נמצאו חנויות באזור: {area}")

    basket_by_store: Dict[str, List[Tuple[str, float]]] = {}
    total_cost = 0.0

    for product in products:
        available = [(store.name, store.prices[product]) for store in local_stores if product in store.prices]
        if not available:
            raise ValueError(f"המוצר '{product}' לא נמצא באף חנות באזור {area}")

        best_store, best_price = min(available, key=lambda item: item[1])
        basket_by_store.setdefault(best_store, []).append((product, best_price))
        total_cost += best_price

    return basket_by_store, total_cost


def single_store_baseline(area: str, products: List[str]) -> Tuple[str, float]:
    local_stores = [store for store in STORES if store.area == area]
    best_name = ""
    best_total = float("inf")

    for store in local_stores:
        if all(product in store.prices for product in products):
            total = sum(store.prices[product] for product in products)
            if total < best_total:
                best_total = total
                best_name = store.name

    if best_total == float("inf"):
        raise ValueError("אין חנות בודדת שמכילה את כל המוצרים")

    return best_name, best_total


def run_demo() -> None:
    area = "תל אביב"
    products = [
        "חלב 3% 1 ליטר",
        "לחם אחיד",
        "ביצים L 12 יחידות",
        "אורז 1 ק\"ג",
        "פסטה 500 גרם",
        "עגבניות 1 ק\"ג",
        "מלפפונים 1 ק\"ג",
        "חזה עוף 1 ק\"ג",
        "גבינה לבנה 250 גרם",
        "שמן קנולה 1 ליטר",
    ]

    split_basket, split_total = optimize_basket(area, products)
    baseline_store, baseline_total = single_store_baseline(area, products)
    savings = baseline_total - split_total

    print("=" * 70)
    print("פיילוט: אופטימיזציית סל קניות (10 מוצרים, ישראל)")
    print(f"אזור: {area}")
    print("=" * 70)

    print(f"\nחלופה א' - קנייה בחנות אחת בלבד: {baseline_store}")
    print(f"סה\"כ: ₪{baseline_total:.2f}")

    print("\nחלופה ב' - פיצול אוטומטי בין חנויות (הכי זול):")
    for store_name, items in split_basket.items():
        store_total = sum(price for _, price in items)
        print(f"\n{store_name} | סה\"כ לחנות: ₪{store_total:.2f}")
        for product, price in items:
            print(f"  - {product}: ₪{price:.2f}")

    print(f"\nסה\"כ מפוצל: ₪{split_total:.2f}")
    print(f"חיסכון לעומת חנות יחידה: ₪{savings:.2f}")
    print("=" * 70)


if __name__ == "__main__":
    run_demo()
