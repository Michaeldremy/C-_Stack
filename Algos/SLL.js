// We are just adding to the front and removing from the front.


class SLNode {
    constructor(value) {
        this.value = value;
        this.next = null;
    }
}

class SLList {
    constructor() {
        this.head = null;
    }

    // Print the whole list
    printList() {
        if(this.head == null) {
            console.log("The list is empty.");
            return this;
        }
        let str = "H: ";
        let runner = this.head;
        while(runner != null) {
            str += `${runner.value} -> `
            runner = runner.next;
        }
        console.log(str);
        return this;
    }

    // Is the list empty?
    isEmpty() {
        if(this.head == null) {
            return true;
        }
        return false;
    }

    // Add to back
    addToBack(value) {
        if(this.head == null) {
            this.head = new SLNode(value);
            return this;
        }
        let runner = this.head;

        while(runner.next != null) {
            runner = runner.next;
        }
        runner.next = new SLNode(value);
        return this;
    }

    // Add to front
    addToFront(value) {
        // create the new node we want to add to the front
        var newNode = new SLNode(value);
        // set the new node's next to the current head
        newNode.next = this.head;
        // reassign the head to the new start of the list
        this.head = newNode;
        return this;
    }

    // Remove from front
    removeFromFront() {
        // If the list is empty, there's nothing to remove.
        if(this.head == null){
            return "This list is empty.";
        }
        // set a temporary variable as the head to return the node we're removing
        var temp = this.head;
        // set the head to the next node in the list (this still works if the list is only
        // one element long, as the head's next will be null and a list with a null head is 
        // an empty list)
        this.head = this.head.next;

        // return the removed node
        return temp;
    }

    // Contains. Challenge --> Do this recursively
    contains(value) {
        // return a boolean: if the value is in the list, return true, else return false
        if(this.head == null){
            return false;
        }
        // Set our runner to traverse through the list
        let runner = this.head;
        while(runner != null) {
            // check if the runner's value matches the value we're searching for
            if(runner.value == value) {
                return true;
            }
            // move it along
            runner = runner.next;
        }
        // if we've reached the end of our list and NOT found the value, then it must not be in here
        return false;
    }

    // same as above but recursively
    rContains(value, runner = this.head) {
        // check for empty list or end of list because of recursion
        if(runner == null) {
            return false;
        }
        // check if runner's value is the value we're looking for
        else if(runner.value == value) {
            return true;
        }
        // make recursive call and return it so as soon as the end of the call stack finishes it shoots back up the chain
        return this.rContains(value, runner.next);
    }

    // Remove from the back of a singly linked list
    removeFromBack() {
        if(this.head == null) {
            return this;
        }
        else if(this.head.next == null) {
            this.head = null;
            return this;
        }
        let runner = this.head;
        let walker = null;
        while(runner.next != null) {
            walker = runner;
            runner = runner.next;
        }
        walker.next = null;
        return this;
    }

    // Move the smallest number to the front of the singly linked list
    moveMinToFront() {
        if(this.head == null) {
            return this;
        }
        let runner = this.head;
        let walker = null;
        let min = this.head;
        let minprev = null;

        while(runner.next != null) {
            if(runner.value < min.value) {
                min = runner;
                minprev = walker;
            }
            walker = runner;
            runner = runner.next;
        }
        if(min == this.head) {
            return this;
        }
        minprev.next = min.next;
        min.next = this.head;
        this.head = min;
        return this;
    }

    // Remove the first node with the given value from the list
    removeVal(value) {
        if(this.head == null) {
            console.log("List is empty");
            return this;
        }
        else if(this.head.value == value) {
            this.head = this.head.next;
            return this;
        }
        let runner = this.head;
        let walker = null;
        while(runner != null) {
            if(runner.value == value) {
                walker.next = runner.next;
                return this;
            }
            walker = runner;
            runner = runner.next;
        }
        console.log("Value not found.")
        return this;

    }

    // Write an algorithm that returns the second-to-last value of a Singly Linked List
    secondToLast(){
        // Check to see if there even WILL be a second to last node.
        if(this.head == null || this.head.next == null){
            return false;
        }
        // set walker to the the first node and runner to the 2nd node
        let walker = this.head;
        let runner = walker.next;
        // traverse until walker reaches the last node and walker reaches the second to last node
        while(runner.next != null) {
            walker = runner;
            runner = runner.next;
        }
        // print the second to last value and return the list for chaining
        console.log(walker.value);
        return this;
    }

    // Write an algorithm that, given a second SLL, concatenates it to the end of another SLL
    concat(list2) {
        // check to see if the first list is empty
        if(this.head == null) {
            // if it is empty, just set this list's head to the head of the second list
            this.head = list2.head;
            // clear the second list 
            list2.head = null;
            return this;
        }
        // set runner to this list's head and traverse to the end of the list
        let runner = this.head;
        while(runner.next != null) {
            runner = runner.next;
        }
        // once at the end, set the next to list 2's head and clear list 2
        runner.next = list2.head;
        list2.head = null;
        return this;
    }

    // Write an algorithm that, assuming this list is sorted, will merge it together with another passed in SLL
    merge(list2) {
        // If the first list is empty, just set the list's head to the head of the second list.
        if(this.head == null) {
            this.head = list2.head;
            // then make sure to clear the second list
            list2.head = null;
            return this;
        }
        // if the second list is empty, there's really no second list to merge so return this list
        else if (list2.head == null) {
            return this;
        }
        // If the second list's head's value is smaller than the first list's head, just swap them 
        // for an easy way to make sure list 1 starts with the smallest value
        else if(list2.head.value < this.head.value) {
            let temp = this.head;
            this.head = list2.head;
            list2.head = temp;
        }

        // 2 lists = 2 runners
        let runner1 = this.head;
        let runner2 = list2.head;
        
        // We'll be checking runner1's next's value so make sure runner1.next isn't null
        while(runner1.next != null) {
            // if we've reached the end of the second list, we're basically done.
            if(runner2 == null) {
                list2.head = null;
                return this;
            }
            // at this point we know that runner 2's value is greater than runner 1's value
            // so if runner 2 is greater than runner 1 but less than runner 1's next, then we
            // want to wedge it on in between
            else if(runner1.next.value > runner2.value) {
                let temp1 = runner1.next;
                let temp2 = runner2.next;
                runner1.next = runner2;
                runner2.next = temp1;
                runner2 = temp2;
            }
            // otherwise just move it along
            else {
                runner1 = runner1.next;
            }
        }

        // if we've reached the end of list 1 and there's still nodes left in list 2, tack them onto the end of list 1
        if(runner2 != null) {
            runner1.next = runner2;
        }
        // make sure list 2 is now empty and return
        list2.head = null;
        return this;
    }

    // Write an algorithm that, assuming all lists are sorted, will merge together k number of sorted SLL's [list1, list2, list3, list4, ..., listk]
    mergeK(arrayoflists) {
        // this one is much easier assuming you've completed the merge function.
        // just loop through the array of lists and merge each one into this list
        for(let i = 0; i < arrayoflists.length; i++) {
            this.merge(arrayoflists[i]);
        }

        return this;
    }

    // Write an algorithm that will reverse a singly linked list.
    // REMINDER! You not only need to reverse the order of the nodes themselves,
    // but must also remember to set the previous end of the list as the new head of the list.
    reverse() {

    }
}

// Stack order: Last In First Out
// Same deal as with the Queue: use the methods within the SLList to write algorithms for these functionalities of a stack
class Stack {
    constructor() {
        this.stack = new SLList();
    }
    
    // Adding to the "top" of the stack 
    push(value) {
        return this.stack.addToFront(value)
    }

    // Remove from the "top" of the stack
    pop() {
        return this.stack.removeFromFront()
    }

    // Show the value of the "top" of the stack
    peek() {
        return this.stack.head;
    }

    // Is there anything actually in the stack?
    isEmpty() {
        return this.stack.head == null;
        }

    // How many things are in the stack
    size() {
        let count = 0;
        if(this.stack.head == null) {
            return count;
        }
        let runner = this.stack.head;
        while(runner != null) {
            runner = runner.next;
            count++;
        }
        return count;
    }
}

    // Create a queue using 2 stacks. A hint: stack_1 will hold the contents of the actual queue, stack_2 will be used in the enQueueing and deQueueing
    class QueueOfStacks {
        constructor() {
            this.stack_1 = new Stack();
            this.stack_2 = new Stack();
        }

        enQueue(value) {
            var walker = this.stack_1.head;
            while (walker != null){
                this.stack_2.push(this.stack_1.pop())
                walker = walker.next;
            }
            this.stack_1.head = new SLNode(value);
            var walker2 = this.stack_2.head;
            while (walker2 != null){
                this.stack_1.push(this.stack_2.pop());
                walker2 = walker2.next;
            }
            return this;
        }

        deQueue() {
            return this.stack_1.pop();
        }

        front() {
            if(this.stack_1 != null) {
                console.log(this.stack_1.head.value);
                return this;
            }
            console.log("The queue is empty.")
            return this;
        }

        isEmpty() {
            if(this.stack_1.head == null) {
                return true;
            }
            return false;
        }

        size() {
            let count = 0;
            if(this.stack_1.head == null) {
                return count;
            }
            let runner = this.stack_1.head;
            while(runner != null) {
                runner = runner.next;
                count++;
            }
            return count;
        }
    }