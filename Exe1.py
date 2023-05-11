def print_triangle_line(space, stars):
    print(" " * space + "*" * stars)


def print_triangle_case(triangle_base, triangle_height):
    if triangle_base % 2 == 0 or triangle_base > 2 * triangle_height or not triangle_base.is_integer() or not triangle_height.is_integer():
        print("Error: Can't print the triangle")
        return
    triangle_base = int(triangle_base)
    triangle_height = int(triangle_height)
    lst = list(zip(range(1, triangle_base + 1, 2), range(triangle_base // 2, -1, -1)))
    num = (triangle_height - 2) // (len(lst) - 2)
    num1 = (triangle_height - 2) % (len(lst) - 2)
    print_triangle_line(lst[0][1], lst[0][0])
    for i in range(num1):
        print_triangle_line(lst[1][1], lst[1][0])
    for i, j in lst[1:-1]:
        for k in range(num):
            print_triangle_line(j, i)
    print_triangle_line(lst[-1][1], lst[-1][0])


def rectangle_case(rectangle_width, rectangle_height):
    difference = abs(rectangle_height - rectangle_width)
    if difference == 0 or difference > 5:
        print("The area of the rectangle is: ", rectangle_width * rectangle_height)
    else:
        print("The perimeter of the rectangle is: ", 2 * (rectangle_width + rectangle_height))


def triangle_case(triangle_base, triangle_height):
    print("Enter 1 to print the perimeter of the triangle and any other key to print the triangle")
    choice = input()
    if choice == '1':
        calculate_triangle_perimeter(triangle_base, triangle_height)
    else:
        print_triangle_case(triangle_base, triangle_height)


def calculate_triangle_perimeter(triangle_base, triangle_height):
    # Calculate the length of the equal sides
    try:
        equal_side = (triangle_base ** 2 + 4 * triangle_height ** 2) ** 0.5 / 2
        print("The perimeter of the triangle is:", 2 * equal_side + triangle_base)
    except ValueError:
        print("Invalid input. Unable to calculate the perimeter.")


def get_height_width(shape):
    # Get the width and height from the user
    try:
        height = float(input("Enter the height of the " + shape + ": "))
        width = float(input("Enter the width of the " + shape + ": "))
        return height, width
    except ValueError:
        print("Invalid input. Please enter numeric values.")
        return None, None


def print_options_and_check_answer():
    print("Enter 1 for rectangle, 2 for triangle, or 3 to exit")
    choice = input()
    if choice == '1':
        height, width = get_height_width("rectangle")
        if height is not None and width is not None:
            rectangle_case(width, height)
    elif choice == '2':
        height, width = get_height_width("triangle")
        if height is not None and width is not None:
            triangle_case(width, height)
    elif choice == '3':
        return "Exit"
    else:
        print("Invalid choice. Please enter a valid option.")
    return ""


ans = ""
while ans != "Exit":
    ans = print_options_and_check_answer()
