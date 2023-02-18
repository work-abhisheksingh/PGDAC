package com.app.foodtype;

public enum foodtype {
	MAIN_COURSE("Main Course"), DESSERT("Dessert"), SNACK("Snack"), BEVERAGE("Beverage");

	private final String displayName;

	foodtype(String displayName) {
		this.displayName = displayName;
	}

	public String getDisplayName() {
		return displayName;
	}
}
